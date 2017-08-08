using System;

namespace WebFormsChat.Frontend.Pages {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SubmitHandler(object sender, EventArgs e) {
            string userName = UserName.Text,
                   password = Password.Text,
                   confirmPassword = ConfirmPassword.Text;

            Response.Redirect($"{Request.Url}?{userName}{password}{confirmPassword}");
        }
    }
}