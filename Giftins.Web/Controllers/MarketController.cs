using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Data.UserContext;

namespace Giftins.Web.Controllers
{
    using Models.Market;

    [Authorize]
    public class MarketController : BaseController
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public MarketController(ILogger<MarketController> logger,
            IMediator mediator,
            UserManager<GiftinsUser> userManager)
            : base(logger, mediator)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();

            model.StatusMessage = StatusMessage;
            return View(model);
        }
    }
}
