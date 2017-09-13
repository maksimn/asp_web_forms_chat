using System.Threading.Tasks;
using System.Web.WebSockets;

namespace WebFormsChat.Frontend.Services {
    public interface IWebSocketChatMessageService {
        Task WebSocketChatMessages(AspNetWebSocketContext context);
    }
}
