﻿using WebFormsChat.Frontend.Models;

namespace WebFormsChat.Frontend.Services {
    public interface IAuthService {
        void RegisterUser(UserRegistrationData userData);

        bool AuthenticateUser(string userName, string password);
    }
}