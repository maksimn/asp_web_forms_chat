using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsChat.Frontend.Services;
using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Tests {
    [TestClass]
    public class AuthServiceTests {
        [TestMethod]
        public void RegisterUser__AddToEmptyUserSet() {
            string username = "Andrew", password = "abc123";

            AuthService authService = new AuthService();

            authService.RegisterUser(username, password);

            IChatRepository repository = new MemoryRepository();
            var user = repository.GetUserByName(username);

            Assert.AreEqual(username, user.Name);
        }
    }
}
