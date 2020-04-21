using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Giftins.Web.Views.Settings
{
    public static class SettingsNavPages
    {
        public static string ActivePageKey => "SettingsNavActivePage";

        public static string Main => "Main";
        public static string Security => "Security";
        public static string Personal => "Personal";
        public static string Privacy => "Privacy";

        public static string MainSettingsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Main);
        public static string SecurityNavClass(ViewContext viewContext) => PageNavClass(viewContext, Security);
        public static string PersonalNavClass(ViewContext viewContext) => PageNavClass(viewContext, Personal);
        public static string PrivacyNavClass(ViewContext viewContext) => PageNavClass(viewContext, Privacy);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData[ActivePageKey] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
