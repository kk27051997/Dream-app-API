using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QuotesApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Formatters.Remove(config.Formatters.XmlFormatter);//this removes xml and gives json
            // config.Formatters.Remove(config.Formatters.JsonFormatter);//this removes json and gives xml
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));//this gives json in client side and in postman we can design accordingly

        }
    }
}
