using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;
using WebFormsChat.Frontend.Models;

namespace WebFormsChat.Frontend.Services {
    public sealed class AuthService : IAuthService {
        private IUserRepository _repository;

        public AuthService(IUserRepository repository) {
            _repository = repository;
        }

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