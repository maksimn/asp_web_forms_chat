using Microsoft.Practices.Unity;
using System;
using System.Web.Security;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Login : System.Web.UI.Page {
        [Dependency]
        public IAuthService AuthService { get; set; }

        protected void SubmitHandler(object sender, EventArgs e) {
            var isAuthenticated = AuthService.AuthenticateUser(UserName.Text, Password.Text);

            if (isAuthenticated) {
                FormsAuthentication.SetAuthCookie(UserName.Text, false);
                Response.Redirect("~/Pages/Chat.aspx");
            } else {
                LoginDataValidation.IsValid = false;
            }
        }
    }
}