﻿using Microsoft.Practices.Unity;
using System;
using System.Web;
using System.Web.Routing;

namespace WebFormsChat.Frontend {
    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterTypes();
        }

        private static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("Register", "Pages/Register.aspx", "~/Pages/Register.aspx");
            routes.MapPageRoute("Login", "Pages/Login.aspx", "~/Pages/Login.aspx");
            routes.MapPageRoute("Any", "{*url}", "~/Pages/Chat.aspx");
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
            var handler = HttpContext.Current.Handler as System.Web.UI.Page;

            if (handler != null) {
                var container = UnityConfig.GetContainer();

                container.BuildUp(handler.GetType(), handler);
            }
        }

        protected void Application_End(object sender, EventArgs e) {
            UnityConfig.ReleaseContainer();
        }
    }
}