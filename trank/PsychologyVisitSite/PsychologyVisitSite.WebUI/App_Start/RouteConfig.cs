using System.Web.Mvc;
using System.Web.Routing;

namespace PsychologyVisitSite.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "{controller}/{action}",
                new { controller = "Nav", action = "FlexMenu" });

            routes.MapRoute(
                null,
               "{controller}/{action}",
               new { controller = "MeetingEvents", action = "EventSummary" });

            routes.MapRoute(
                name: "Registration",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registration", action = "Registrate", id = UrlParameter.Optional });

            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "HomePage", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "HomePage", id = UrlParameter.Optional });

            routes.MapRoute(
                null,
                "",
                new { controller = "Home", action = "HomePage", id = UrlParameter.Optional });
        }
    }
}
