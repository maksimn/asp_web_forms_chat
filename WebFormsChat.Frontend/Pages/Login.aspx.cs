using Microsoft.Practices.Unity;
using System;
using System.Web.Security;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Login : System.Web.UI.Page {
        [Dependency]
        public IAuthService AuthService { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            if (User.Identity.IsAuthenticated) {
                Response.Redirect("~/Pages/Chat.aspx");
            }
        }

        protected void SubmitHandler(object sender, EventArgs e) {
            var isAuthenticated = AuthService.AuthenticateUser(UserName.Text, Password.Text);

            if (isAuthenticated) {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
            } else {
                LoginDataValidation.IsValid = false;
            }
        }
    }
}