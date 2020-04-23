using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Giftins.Web.Areas.Installation.Middleware
{
    public class InstallationMiddleware
    {
        private bool? _installed = null;

        private readonly RequestDelegate _next;
        private readonly string _redirectUrl;

        public InstallationMiddleware(RequestDelegate next, string redirectUrl)
        {
            _next = next;
            _redirectUrl = redirectUrl;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!_installed.HasValue)
                _installed = IsInstalled();

            if (_installed != true
                && !context.Request.Path.Value.Contains(_redirectUrl))
            {
                context.Response.Redirect(_redirectUrl);
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        protected bool IsInstalled()
        {
            return true;
        }
    }

    public static class InstallationMiddlewareExtension
    {
        public static IApplicationBuilder UseGiftinsInstallation(this IApplicationBuilder builder, string redirectUrl)
        {
            return builder.UseMiddleware<InstallationMiddleware>(redirectUrl);
        }
    }
}