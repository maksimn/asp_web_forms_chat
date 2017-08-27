using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public interface IChatRepository {
        void AddUser(UserRegistrationInput input);
        User GetUserByName(string userName);
        int UserCount { get; }
        void Clear();
    }
}
