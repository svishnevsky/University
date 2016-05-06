using System.Web.Mvc;
using System.Web.Routing;

namespace GrSU.University.Clients.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "New",
                url: "{controller}/new",
                defaults: new { action = "New" }
            );

            routes.MapRoute(
                name: "RoomItem",
                url: "Rooms/{id}",
                defaults: new { controller = "Room", action = "Index" }
            );

            routes.MapRoute(
                name: "StudentGroupItem",
                url: "StudentGroups/{id}",
                defaults: new { controller = "StudentGroup", action = "Index" }
            );

            routes.MapRoute(
                name: "StudentItem",
                url: "Students/{id}",
                defaults: new { controller = "Student", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Rooms", action = "Index" }
            );
        }
    }
}
