using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UsersAsp2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //se non ci basta più il map route di default ne creiamo uno nuovo
            /*routes.MapRoute(
                name: "GetOneByUsername",
                url: "Users/GetOneByUsername/{username}",
                defaults: new {controller = "Users", action="GetOneByUsername"}
                );*/
            //adesso in realtà possiamo usare l'attribute routing (che nei progetti non api non è di default e va attivato con routes.MapMvcAttributeRoutes();)
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //il routing di default nasce per gestire un parametro aggiuntivo nell'url
                                                   //e lo chiama id e lo passa come parametro del metodo index
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
