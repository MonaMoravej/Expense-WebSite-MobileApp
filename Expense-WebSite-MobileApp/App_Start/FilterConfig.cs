using System.Web;
using System.Web.Mvc;

namespace Expense_WebSite_MobileApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
