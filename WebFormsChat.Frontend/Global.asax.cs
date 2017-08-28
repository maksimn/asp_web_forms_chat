using Microsoft.Practices.Unity;
using System;
using System.Web;

namespace WebFormsChat.Frontend {
    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            UnityConfig.RegisterTypes();
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