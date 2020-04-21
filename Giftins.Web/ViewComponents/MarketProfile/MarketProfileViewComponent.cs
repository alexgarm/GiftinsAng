using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Core.Exceptions;
using Giftins.Application.Market.GetMarketProfile;

namespace Giftins.Web.ViewComponents.MarketProfile
{
    public class MarketProfileViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly UserManager<GiftinsUser> _userManager;

        public MarketProfileViewComponent(IMediator mediator,
            UserManager<GiftinsUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var query = new GetMarketProfileQuery()
            {
                UserId = userId
            };

            try
            {
                var marketProfile = await _mediator.Send(query);
                var model = new MarketProfileViewModel()
                {
                    MarketId = marketProfile.MarketId,
                    Name = marketProfile.Name,
                    Slogan = marketProfile.Slogan,
                    PictureUrl = marketProfile.Picture
                };

                return View(model);
            }
            catch (GiftinsException gEx)
            {

            }

            throw new NotImplementedException();
        }
    }
}
