using System;
using System.Data;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Register : System.Web.UI.Page {
        private AuthService authService = new AuthService();
        private bool isRegisterSuccess = false;
        private bool didRegistrationErrorHappen = false; 

        public string IsRegisterSuccess {
            get { return isRegisterSuccess.ToString().ToLower(); }
        }

        public string DidRegistrationErrorHappen {
            get { return didRegistrationErrorHappen.ToString().ToLower(); }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void SubmitHandler(object sender, EventArgs e) {
            try {
                authService.RegisterUser(UserName.Text, Password.Text);
                isRegisterSuccess = true;
            } catch(DuplicateNameException) {
                UserNameDuplicationValidation.IsValid = false;
            } catch(Exception) {
                didRegistrationErrorHappen = true;
            }
        }
    }
}