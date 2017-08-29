using System.Collections.Generic;
using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public interface IMessageRepository {
        IEnumerable<ChatMessage> ChatMessages { get; }
    }
}
