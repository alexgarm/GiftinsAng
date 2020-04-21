using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Data.UserContext;

namespace Giftins.Web.Controllers
{
    using Models.User;

    [Authorize]
    public partial class UserController : BaseController
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public UserController(ILogger<UserController> logger,
            IMediator mediator,
            UserManager<GiftinsUser> userManager)
            : base(logger, mediator)
        {
            _userManager = userManager;
        }

        [HttpGet]
        // User profile
        public IActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction(nameof(Friends));

            IndexViewModel model = new IndexViewModel()
            {

            };

            model.StatusMessage = StatusMessage;
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Friends()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Bill()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Wish()
        {
            return View();
        }
    }
}
