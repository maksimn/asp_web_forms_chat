using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;
using WebFormsChat.Frontend.Models;

namespace WebFormsChat.Frontend.Services {
    public sealed class AuthService {
        private IChatRepository _repository = new MemoryRepository();

        public void RegisterUser(UserRegistrationData userData) {
            var userRegistrationInput = new UserRegistrationInput() {
                UserName = userData.UserName,
                Password = userData.Password
            };
            _repository.AddUser(userRegistrationInput);
        }
    }
}