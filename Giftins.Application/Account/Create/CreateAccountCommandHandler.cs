using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;
using Giftins.Core.Exceptions;
using Giftins.Data;

namespace Giftins.Application.Account.Create
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResult>
    {
        public const string FAILED_ERROR_MESSAGE = "Failed to create new account.";

        private readonly CreateAccountCommandValidator _validator;
        private readonly IMapper _mapper;
        private readonly UserManager<GiftinsUser> _userManager;
        private readonly AccountDbContext _accountDbContext;

        public CreateAccountCommandHandler(CreateAccountCommandValidator validator, IMapper mapper, UserManager<GiftinsUser> userManager, AccountDbContext accountDbContext)
        {
            _validator = validator;
            _mapper = mapper;
            _userManager = userManager;
            _accountDbContext = accountDbContext;
        }

        public async Task<CreateAccountResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);

            try
            {
                var user = _mapper.Map<GiftinsUser>(request);

                IdentityResult res = null;
                if (string.IsNullOrEmpty(request.Password))
                    res = await _userManager.CreateAsync(user).ConfigureAwait(false);
                else
                    res = await _userManager.CreateAsync(user, request.Password).ConfigureAwait(false);

                if (res.Succeeded)
                {
                    try
                    {
                        UserProfile profile = new UserProfile(user.Id);
                        _mapper.Map(request, profile);
                        _accountDbContext.UserProfiles.Add(profile);

                        await _accountDbContext.SaveChangesAsync().ConfigureAwait(false);

                        return CreateAccountResult.Success(user.Id);
                    }
                    // DbUpdateException - unique index violation
                    // DbUpdateConcurrencyException - concurrency issues 
                    // NotSupportedException
                    // ObjectDisposedException
                    // InvalidOperationException
                    catch (Exception ex)
                    {
                        await _userManager.DeleteAsync(user).ConfigureAwait(false); // Hope no error here
                        throw new GiftinsInternalException(FAILED_ERROR_MESSAGE, ex);
                    }
                }
                else
                    return CreateAccountResult.Failed(res.Errors);
            }
            catch (Exception ex)
            {
                throw new GiftinsException(FAILED_ERROR_MESSAGE, ex);
            }
        }
    }
}
