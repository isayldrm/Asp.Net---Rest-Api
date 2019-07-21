using ProgramingWebApi.Attributes;
using ProgramingWebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProgramingWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //hata mesajı yakalamak icin
            config.Filters.Add(new ApiExceptionAttribute());
            //authorization islemleri icin
            config.MessageHandlers.Add(new ApiKeyHandler());


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //sonucları Json Formatta dondurmek
            config.Formatters.JsonFormatter.SerializerSettings.
                Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
