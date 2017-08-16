using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsChat.Frontend.Services;
using WebFormsChat.ChatData.Repositories;
using System.Data;

namespace WebFormsChat.Tests {
    [TestClass]
    public class AuthServiceTests {
        private AuthService _authService;
        private IChatRepository _repository; 

        [TestInitialize]
        public void Init() {
            _authService = new AuthService();
            _repository = new MemoryRepository();
        }

        [TestCleanup]
        public void Cleanup() {
            _repository.Clear();
        }

        [TestMethod]
        public void RegisterUser__SingleUser() {
            string username = "Andrew", password = "abc123";

            _authService.RegisterUser(username, password);
            var user = _repository.GetUserByName(username);

            Assert.AreEqual(username, user.Name);
            Assert.AreEqual(1, _repository.UserCount);
        }

        [TestMethod]
        public void RegisterUser__TwoUsers() {
            string username1 = "Andrew", password1 = "abc123", 
                username2 = "Jen", password2 = "123";

            _authService.RegisterUser(username1, password1);
            _authService.RegisterUser(username2, password2);
            var user1 = _repository.GetUserByName(username1);
            var user2 = _repository.GetUserByName(username2);

            Assert.AreEqual(username1, user1.Name);
            Assert.AreEqual(username2, user2.Name);
            Assert.AreEqual(2, _repository.UserCount);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void RegisterUser__TwoUsersWithSameName__ThrowsDuplicateNameException() {
            string username1 = "Andrew", password1 = "abc123";

            _authService.RegisterUser(username1, password1);
            _authService.RegisterUser(username1, password1);
        }
    }
}
