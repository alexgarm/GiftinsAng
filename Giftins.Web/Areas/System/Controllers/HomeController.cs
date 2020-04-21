using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Giftins.Core.Domain.User;

namespace Giftins.Web.Areas.System.Controllers
{

    [Area("system")]
    [Authorize(Roles = GiftinsRole.ROOT)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
