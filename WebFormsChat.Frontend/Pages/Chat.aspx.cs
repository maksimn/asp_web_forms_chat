using Microsoft.Practices.Unity;
using System;
using System.Web.Security;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Chat : System.Web.UI.Page {
        [Dependency]
        public IChatService ChatService { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            if (!User.Identity.IsAuthenticated) {
                Response.StatusCode = 401;
                Response.End();
            }
        }

        protected void SignOutHandler(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
        }
    }
}