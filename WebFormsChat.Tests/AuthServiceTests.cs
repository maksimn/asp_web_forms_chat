using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsChat.Frontend.Models;
using WebFormsChat.Frontend.Services;
using WebFormsChat.ChatData.Repositories;
using System.Data;

namespace WebFormsChat.Tests {
    [TestClass]
    public class AuthServiceTests {
        private AuthService _authService;
        private IUserRepository _repository; 

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
            var userData = new UserRegistrationData() { UserName = "Andrew", Password = "abc123" };
            _authService.RegisterUser(userData);
            var user = _repository.GetUserByName(userData.UserName);

            Assert.AreEqual(userData.UserName, user.Name);
            Assert.AreEqual(1, _repository.UserCount);
        }

        [TestMethod]
        public void RegisterUser__TwoUsers() {
            var userData1 = new UserRegistrationData() { UserName = "Andrew", Password = "abc123" };
            var userData2 = new UserRegistrationData() { UserName = "Jen", Password = "123" };

            _authService.RegisterUser(userData1);
            _authService.RegisterUser(userData2);
            var user1 = _repository.GetUserByName(userData1.UserName);
            var user2 = _repository.GetUserByName(userData2.UserName);

            Assert.AreEqual(userData1.UserName, user1.Name);
            Assert.AreEqual(userData2.UserName, user2.Name);
            Assert.AreEqual(2, _repository.UserCount);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void RegisterUser__TwoUsersWithSameName__ThrowsDuplicateNameException() {
            var userData = new UserRegistrationData() { UserName = "Andrew", Password = "abc123" };

            _authService.RegisterUser(userData);
            _authService.RegisterUser(userData);
        }
    }
}
