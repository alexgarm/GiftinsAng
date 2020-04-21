using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediatR;

using Giftins.TestUtils;
using Giftins.Data;
using Giftins.TestUtils.Initializers;
using Microsoft.AspNetCore.Identity;
using Giftins.Core.Domain.User;

namespace Giftins.Application.Tests
{
    public class ApplicationTestBase
    {
        protected readonly IServiceProvider _services;
        protected readonly IMediator _mediator;

        protected readonly UserManager<GiftinsUser> _userManager;
        protected readonly AccountDbContext _accountDbContext;
        protected readonly UserDbContext _userDbContext;

        public ApplicationTestBase()
        {
            _services = ServiceProviderFactory.CreateGiftinsServicesCollection();
            _mediator = (IMediator)_services.GetService(typeof(IMediator));

            _userManager = (UserManager<GiftinsUser>)_services.GetService(typeof(UserManager<GiftinsUser>));
            _accountDbContext = (AccountDbContext)_services.GetService(typeof(AccountDbContext));
            _userDbContext = (UserDbContext)_services.GetService(typeof(UserDbContext));
        }
    }
}
