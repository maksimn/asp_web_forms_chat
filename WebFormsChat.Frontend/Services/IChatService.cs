using System.Collections.Generic;
using WebFormsChat.ChatData.Models;

namespace WebFormsChat.Frontend.Services {
    public interface IChatService {
        IEnumerable<ChatMessage> ChatMessages { get; }
    }
}
