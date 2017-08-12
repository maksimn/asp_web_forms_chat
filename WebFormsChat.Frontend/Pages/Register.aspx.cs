using System;
using System.Data;
using System.Web.UI.WebControls;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Register : System.Web.UI.Page {
        private AuthService _authService = new AuthService();

        protected void Page_Load(object sender, EventArgs e) {

        }

        public void CheckUserNameDuplication(object source, ServerValidateEventArgs e) {

        }

        protected void SubmitHandler(object sender, EventArgs e) {
            string userName = UserName.Text,
                   password = Password.Text;

            // Если регистрация пользователя прошла успешно, он должен быть переведен на страницу
            // логина. О том, что регистрация пользователя успешна, должно быть выведено сообщение 
            // в alert() на странице.
            // Если имя уже занято, должно быть выведено сообщение "Пользователь с данным именем 
            // уже существует. Попробуйте другое имя" в области валидации.
            // Если произошла какая-то другая ошибка, о ней должно быть выведено сообщение
            // (возможно, общая страница для отображения ошибок приложения).
            try {
                _authService.RegisterUser(userName, password);
            } catch(DuplicateNameException) {

            } catch(Exception exc) {
                throw exc;
            }
        }
    }
}