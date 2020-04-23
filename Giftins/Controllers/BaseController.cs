using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Giftins.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Redirect controller for external returnUrl
        /// </summary>
        protected virtual string REDIRECT_CONTROLLER => "Home";
        /// <summary>
        /// Redirect action for external returnUrl
        /// </summary>
        protected virtual string REDIRECT_ACTION => "Index";

        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        [TempData]
        protected string StatusMessage { get; set; }

        public BaseController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return RedirectToLocal(returnUrl);

            return RedirectToAction(REDIRECT_ACTION, REDIRECT_CONTROLLER, new { area = "" });
        }
    }
}
