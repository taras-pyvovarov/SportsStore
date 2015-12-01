using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Url: '/' 
            //Lists the first page of products from all categories
            routes.MapRoute(null, "",
                new { controller = "Product", action = "List", category = (string)null, page = 1 });

            //Url: '/Page2' 
            //Lists the specified page, showing items from all categories
            routes.MapRoute(null, "Page{page}", 
                new { controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" });

            //Url: '/Soccer'
            //Shows the first page of items from a specific category
            routes.MapRoute(null, "{category}",
                new { controller = "Product", action = "List", category = (string) null });

            //Url: '/Soccer/Page2'
            //Shows the specified page (in this case, page 2) of items from the specified category
            routes.MapRoute(null, "{category}/Page{page}", 
                new { controller = "Product", action = "List" },
                new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}