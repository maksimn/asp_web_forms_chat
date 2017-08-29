using System;

namespace WebFormsChat.Frontend.Pages {
    public partial class Chat : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!User.Identity.IsAuthenticated) {
                Response.StatusCode = 401;
                Response.End();
            }
        }
    }
}