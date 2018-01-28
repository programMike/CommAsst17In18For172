using System.Web;
using System.Web.Mvc;

namespace CommAsst17in18for172
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
