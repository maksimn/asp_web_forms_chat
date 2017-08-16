using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Frontend.Services {
    public sealed class AuthService {
        private IChatRepository _repository = new MemoryRepository();

        public void RegisterUser(string userName, string password) {
            _repository.AddUser(userName, password);
        }
    }
}