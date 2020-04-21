using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Giftins.Web.Views.User
{
    public static class UserNavPages
    {
        public static string ActivePageKey => "UserNavActivePage";

        public static string Friends => "Friends";
        public static string Bill => "Bill";
        public static string Calendar => "Calendar";
        public static string Wish => "Wish";

        public static string FriendsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Friends);
        public static string BillNavCalss(ViewContext viewContext) => PageNavClass(viewContext, Bill);
        public static string CalendarNavCalss(ViewContext viewContext) => PageNavClass(viewContext, Calendar);
        public static string WishNavCalss(ViewContext viewContext) => PageNavClass(viewContext, Wish);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData[ActivePageKey] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
