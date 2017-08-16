using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public interface IChatRepository {
        void AddUser(string userName, string password);
        User GetUserByName(string userName);
    }
}
