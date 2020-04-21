using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using Giftins.Data;
using Giftins.Data.UserContext;
using Giftins.Data.UserContext.Initializing;

namespace Giftins.Web.Areas.Controllers.Installation
{
    [Area("installation")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        /*
        private readonly IGiftinsUserContext _userContext;
        private readonly IGiftinsMediaContext _mediaContext;
        private readonly IGiftinsMarketContext _marketContext;
        private readonly IGiftinsOrderContext _ordersContext;

        private readonly UserManager<GiftinsUser> _userManager;
        private readonly RoleManager<GiftinsRole> _roleManager;
        */

        public HomeController(ILogger<HomeController> logger /*,
            IGiftinsUserContext userContext,
            IGiftinsMediaContext mediaContext,
            IGiftinsMarketContext marketContext,
            IGiftinsOrderContext ordersContext,
            UserManager<GiftinsUser> userManager,
            RoleManager<GiftinsRole> roleManager */)
        {
            _logger = logger;
            /*
            _userContext = userContext;
            _mediaContext = mediaContext;
            _ordersContext = ordersContext;

            _userManager = userManager;
            _roleManager = roleManager;
            */
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateDatabase()
        {
            /*
            _userContext.Database.EnsureCreated();
            try
            {
                _userManager.SeedUsers(null);
                _roleManager.SeedRoles();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while initializing smth.");
                return BadRequest();
            }
            */
            return Ok();
        }
    }
}
