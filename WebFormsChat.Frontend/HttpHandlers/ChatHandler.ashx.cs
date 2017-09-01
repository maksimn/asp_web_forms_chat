using Microsoft.Practices.Unity;
using System.Web;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.HttpHandlers {
    public class ChatHandler : IHttpHandler {
        [Dependency]
        public IChatService ChatService { get; set; }

        public void ProcessRequest(HttpContext context) {
            if (context.IsWebSocketRequest) {
                context.AcceptWebSocketRequest(ChatService.WebSocketChatMessages);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}