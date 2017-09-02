using Microsoft.Practices.Unity;
using WebFormsChat.ChatData.Repositories;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend {
    public class UnityConfig {
        private static UnityContainer container = new UnityContainer();

        static UnityConfig() {
            RegisterTypes();
        }
    
        public static void RegisterTypes() {
            // container.RegisterType<IUserRepository, MemoryRepository>();
            container.RegisterType<IUserRepository, SqlRepository>();
            container.RegisterType<IAuthService, AuthService>();

            container.RegisterType<IMessageRepository, MemoryRepository>();
            container.RegisterType<IChatService, ChatService>();
        }

        public static UnityContainer GetContainer() {
            return container;
        }

        public static void ReleaseContainer() {
            container.Dispose();
        }
    }
}