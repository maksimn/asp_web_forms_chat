using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using WebFormsChat.Frontend;
using WebFormsChat.Frontend.Models;
using WebFormsChat.Frontend.Services;
using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Tests {
    [TestClass]
    public class AuthServiceTests {
        private IAuthService _authService;
        private IUserRepository _repository; 

        private UserRegistrationData userData = new UserRegistrationData() {
            UserName = "Andrew", Password = "abc123"
        };

        [TestInitialize]
        public void Init() {
            using (var container = UnityConfig.GetContainer()) {
                _authService = container.Resolve<IAuthService>();
                _repository = container.Resolve<IUserRepository>();
            }
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
            var userData2 = new UserRegistrationData() { UserName = "Jen", Password = "123" };

            _authService.RegisterUser(userData);
            _authService.RegisterUser(userData2);
            var user1 = _repository.GetUserByName(userData.UserName);
            var user2 = _repository.GetUserByName(userData2.UserName);

            Assert.AreEqual(userData.UserName, user1.Name);
            Assert.AreEqual(userData2.UserName, user2.Name);
            Assert.AreEqual(2, _repository.UserCount);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void RegisterUser__TwoUsersWithSameName__ThrowsDuplicateNameException() {
            _authService.RegisterUser(userData);
            _authService.RegisterUser(userData);
        }

        [TestMethod]
        public void AuthenticateUser__CorrectUserData_ReturnsTrue() {
            _authService.RegisterUser(userData);
            var result = _authService.AuthenticateUser(userData.UserName, userData.Password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AuthenticateUser__IncorrectUserData_ReturnsFalse() {
            _authService.RegisterUser(userData);
            var result = _authService.AuthenticateUser(userData.UserName, userData.Password + "1");

            Assert.IsFalse(result);
        }
    }
}
