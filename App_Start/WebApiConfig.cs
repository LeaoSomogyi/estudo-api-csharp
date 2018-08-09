using System.Web.Http;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enable Cors
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Other Web API configuration not shown.
            config.Routes.MapHttpRoute(
                 "WithActionApi",
                 "api/{controller}/{action}/{id}",
                 new { id = System.Web.Http.RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { action = "Get", id = System.Web.Http.RouteParameter.Optional }
            );
        }
    }
}