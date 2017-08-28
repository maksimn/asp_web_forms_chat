﻿using Microsoft.Practices.Unity;
using WebFormsChat.ChatData.Repositories;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend {
    public class UnityConfig {
        private static UnityContainer container = new UnityContainer();

        static UnityConfig() {
            RegisterTypes();
        }
    
        public static void RegisterTypes() {
            container.RegisterType<IUserRepository, MemoryRepository>();
            container.RegisterType<IAuthService, AuthService>();
        }

        public static UnityContainer GetContainer() {
            return container;
        }

        public static void ReleaseContainer() {
            container.Dispose();
        }
    }
}