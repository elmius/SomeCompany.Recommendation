using System.Web;
using System.Web.Mvc;

namespace SomeCompany.Recommendation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
