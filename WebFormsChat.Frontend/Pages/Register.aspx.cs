using Microsoft.Practices.Unity;
using System;
using System.Data;
using WebFormsChat.Frontend.Models;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Register : System.Web.UI.Page {
        private bool isRegisterSuccess = false;
        private bool didRegistrationErrorHappen = false;

        [Dependency]
        public IAuthService AuthService { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            if (User.Identity.IsAuthenticated) {
                Response.Redirect("~/Pages/Chat.aspx");
            }
        }

        public string IsRegisterSuccess {
            get { return isRegisterSuccess.ToString().ToLower(); }
        }

        public string DidRegistrationErrorHappen {
            get { return didRegistrationErrorHappen.ToString().ToLower(); }
        }

        protected void SubmitHandler(object sender, EventArgs e) {
            try {
                var userData = new UserRegistrationData() {
                    UserName = UserName.Text, Password = Password.Text
                };
                AuthService.RegisterUser(userData);
                isRegisterSuccess = true;
            } catch(DuplicateNameException) {
                UserNameDuplicationValidation.IsValid = false;
            } catch(Exception) {
                didRegistrationErrorHappen = true;
            }
        }
    }
}