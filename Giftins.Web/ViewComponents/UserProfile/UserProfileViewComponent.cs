using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Application.Account.GetProfileInfo;

namespace Giftins.Web.ViewComponents.UserProfile
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly UserManager<GiftinsUser> _userManager;
        private readonly IMediator _mediator;

        public UserProfileViewComponent(UserManager<GiftinsUser> userManager,
        IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var profile = await _mediator.Send(new GetProfileInfoQuery()
            {
                AccountId = userId
            });


            var model = new UserProfileViewModel()
            {
                FirstName = profile.FirstName,
                MiddleName = profile.MiddleName,
                LastName = profile.LastName,
                Birthdate = profile.Birthdate,
                Gender = profile.Gender,
                PictureUrl = profile.ImageUrl
            };

            return View(model);
        }
    }
}
