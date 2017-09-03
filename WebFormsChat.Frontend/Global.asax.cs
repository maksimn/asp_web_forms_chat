using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Routing;
using WebFormsChat.Frontend.HttpHandlers;

namespace WebFormsChat.Frontend {
    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            CachingConfig();
            RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterTypes();
        }

        private static void CachingConfig() {
            var cnnStr = ConfigurationManager.ConnectionStrings["WebFormsChat"].ConnectionString;
            SqlCacheDependencyAdmin.EnableTableForNotifications(cnnStr, "ChatMessages");
        }

        private static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("Register", "Pages/Register.aspx", "~/Pages/Register.aspx");
            routes.MapPageRoute("Login", "Pages/Login.aspx", "~/Pages/Login.aspx");
            routes.MapPageRoute("Any", "{*url}", "~/Pages/Chat.aspx");
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
            object handler = HttpContext.Current.Handler as System.Web.UI.Page;

            if (handler == null) {
                handler = HttpContext.Current.Handler as ChatHandler;
            }

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