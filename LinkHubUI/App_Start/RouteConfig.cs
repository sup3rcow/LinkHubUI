using System.Web.Mvc;
using System.Web.Routing;

namespace LinkHubUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //ovako podesis deafaultni area
            (RouteTable.Routes[routes.Count - 1] as Route).DataTokens["area"] = "Common";
        }
    }
}
