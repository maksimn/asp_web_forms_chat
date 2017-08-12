using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Tests {
    [TestClass]
    public class AuthServiceTests {
        [TestMethod]
        public void RegisterUser__AddToEmptyUserSet__Success() {
            AuthService authService = new AuthService();

            authService.RegisterUser("Andrew", "abc123");

            Assert.IsTrue(false);
        }
    }
}
