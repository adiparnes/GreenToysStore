using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreenToys
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("ToyByYearOfManufacture", "Toy/YearOfManufacture/{year}/{month}",
            //    new { Controller = "Toy", Action = "YearOfManufacture" },
            //   constraints: new { year = @"\d{4}" }
            //    //the year in the route have to be with 4 letters
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}
