using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Giftins
{
    public static class GiftinsRoutesExtension
    {
        public static void MapGiftinsRoutes(this IRouteBuilder builder)
        {
            builder.MapRoute(
                name: "login",
                template: "Login",
                defaults: new { controller = "Account", action = "Login" });
            builder.MapRoute(
                name: "register",
                template: "Register",
                defaults: new { controller = "Account", action = "Register" });
            builder.MapRoute(
                name: "logout",
                template: "Logout",
                defaults: new { controller = "Account", action = "Logout" });

            builder.MapRoute(
                name: "settings",
                template: "Settings",
                defaults: new { controller = "Settings", action = "Index" });
            builder.MapRoute(
                name: "profile",
                template: "Profile",
                defaults: new { controller = "Profile", action = "Index" });

            builder.MapRoute(
                name: "friends",
                template: "Friends",
                defaults: new { controller = "User", action = "Friends" });
            builder.MapRoute(
                name: "bill",
                template: "Bill",
                defaults: new { controller = "User", action = "Bill" });
            builder.MapRoute(
                name: "calendar",
                template: "Calendar",
                defaults: new { controller = "User", action = "Calendar" });
            builder.MapRoute(
                name: "wish",
                template: "Wish",
                defaults: new { controller = "User", action = "Wish" });
        }
    }
}
