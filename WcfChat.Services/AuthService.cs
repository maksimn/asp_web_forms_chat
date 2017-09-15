using WcfChat.Contracts;
using WcfChat.Contracts.Data;
using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;

namespace WcfChat.Services {
    class AuthService : IAuthService {
        private IUserRepository _repository = new MemoryRepository();

        public bool AuthenticateUser(string userName, string password) {
            return _repository.LoginUser(userName, password);
        }

        public void RegisterUser(UserRegistrationData userData) {
            var userRegistrationInput = new UserRegistrationInput() {
                UserName = userData.UserName,
                Password = userData.Password
            };
            _repository.AddUser(userRegistrationInput);
        }
    }
}
