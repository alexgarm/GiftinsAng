using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.ComponentModel;
using Giftins.Core.Domain.User;
using Giftins.Core.Exceptions;
using Giftins.Application.Media.GetUploadServer;
using Giftins.Application.Media.UploadPicture;

namespace Giftins.Web.Areas.Pictures.Controllers
{
    using ComponentModel;
    using Models.Pictures;

    [Area("api")]
    [Authorize]
    public class PicturesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly UserManager<GiftinsUser> _userManager;

        public PicturesController(ILogger<PicturesController> logger,
            IMediator mediator,
            UserManager<GiftinsUser> userManager)
        {
            _logger = logger;
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<JsonResult> GetUploadServer()
        {
            var userId = _userManager.GetUserId(User);

            var query = new GetUploadServerQuery()
            {
                UserId = userId
            };

            try
            {
                var server = await _mediator.Send(query);
                return new GJsonResult(server);
            }
            catch (GiftinsException gEx)
            {
                // TODO: do automagically
                return new GJsonResult(GiftinsErrorResponse.Unknown(gEx.Message));
            }
            catch (Exception ex)
            {
                return new GJsonResult(GiftinsErrorResponse.InternalError(ex.Message));
            }
        } 

        [HttpPost]
        public async Task<GJsonResult> UploadPicture(ApiUploadPictureModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var query = new UploadPictureQuery()
                {
                    UserId = userId,
                    ContentType = model.File.ContentType,
                    FileName = model.File.FileName,
                    ImageStream = model.File.OpenReadStream()
                };

                try
                {
                    var imgAddress = await _mediator.Send(query);
                    return new GJsonResult(imgAddress);
                }
                catch (GiftinsException gEx)
                {
                    // TODO: do automagically
                    return new GJsonResult(GiftinsErrorResponse.Unknown(gEx.Message));
                }
                catch (Exception ex)
                {
                    return new GJsonResult(GiftinsErrorResponse.InternalError(ex.Message));
                }
            }
            else
                return new GJsonResult(GiftinsErrorResponse.BadRequest());
        }
    }
}
