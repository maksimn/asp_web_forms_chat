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
            container.RegisterType<IUserRepository, SqlRepository>();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IMessageRepository, SqlRepository>();
            container.RegisterType<IChatService, ChatService>();
            container.RegisterType<ICacheService, AspNetCacheService>();
            container.RegisterType<IWebSocketChatMessageService, WebSocketChatMessageService>();
        }

        public static UnityContainer GetContainer() {
            return container;
        }

        public static void ReleaseContainer() {
            container.Dispose();
        }
    }
}