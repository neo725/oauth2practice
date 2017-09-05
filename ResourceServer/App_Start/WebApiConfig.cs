using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ResourceServer.Attributes;

namespace ResourceServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API CORS 跨域存取啟用
            config.EnableCors();
            
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // add claim scope authorization filter
            config.Filters.Add(new ScopeAttribute());
        }
    }
}
