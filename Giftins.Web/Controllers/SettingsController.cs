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
using Giftins.Core.Exceptions;
using Giftins.Application.Account.GetProfileInfo;
using Giftins.Application.Account.SetProfileInfo;

namespace Giftins.Web.Controllers
{
    using Services;
    using Models.Settings;

    [Authorize]
    public class SettingsController : BaseController
    {
        private readonly SignInManager<GiftinsUser> _signInManager;
        private readonly UserManager<GiftinsUser> _userManager;

        private readonly IEmailSender _emailSender;

        public SettingsController(ILogger<AccountController> logger,
            IMediator mediator,
            SignInManager<GiftinsUser> signInManager,
            UserManager<GiftinsUser> userManager,
            IEmailSender emailSender)
            : base(logger, mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var query = new GetProfileInfoQuery()
            {
                AccountId = userId
            };

            var model = new IndexViewModel();

            try
            {
                var userInfo = await _mediator.Send(query);

                model.FirstName = userInfo.FirstName;
                model.MiddleName = userInfo.MiddleName;
                model.LastName = userInfo.LastName;

                model.GenderId = userInfo.Gender.Id;
                model.Birthdate = userInfo.Birthdate;
                //model.BirthDisplayPolicyId = userInfo.BirthDisplayPolicy.Id;
            }
            catch (GiftinsException gEx)
            {
                model.StatusMessage = gEx.Message;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Security()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Notifications()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetProfileInfo(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                var query = new SetProfileInfoCommand()
                {
                    AccountId = userId,
                    InitiatorId = userId,

                    NewProperties = new Dictionary<string, string>()
                    {
                        { "first_name", model.FirstName },
                        { "middle_name", model.MiddleName },
                        { "last_name", model.LastName },
                        { "bdate", model.Birthdate.ToString() },
                        { "gender", model.GenderId.ToString() },
                        { "bdate_display", model.BirthDisplayPolicyId.ToString() },
                    }
                };

                try
                {
                    var res = await _mediator.Send(query);
                    StatusMessage = "User information successfuly changed.";
                }
                catch (GiftinsException gEx)
                {
                    StatusMessage = gEx.Message;
                }
            }
            else
            {
                // User not meant to get here
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
