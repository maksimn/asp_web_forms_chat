using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public interface IUserRepository {
        void AddUser(UserRegistrationInput input);
        User GetUserByName(string userName);
        bool LoginUser(string userName, string password);
        int UserCount { get; }
        void Clear();
    }
}
