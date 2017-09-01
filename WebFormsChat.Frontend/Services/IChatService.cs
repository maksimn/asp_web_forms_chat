using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.WebSockets;
using WebFormsChat.ChatData.Models;

namespace WebFormsChat.Frontend.Services {
    public interface IChatService {
        IEnumerable<ChatMessage> ChatMessages { get; }

        Task WebSocketChatMessages(AspNetWebSocketContext context);
    }
}
