using System.Linq;
using System.Collections.Generic;
using WcfChat.Contracts;
using WcfChat.Contracts.Data;
using WebFormsChat.ChatData.Repositories;
using ChatMessageModel = WebFormsChat.ChatData.Models.ChatMessage;

namespace WcfChat.Services {
    public class ChatService : IChatService {
        private IMessageRepository _repository = new MemoryRepository();

        public void AddChatMessage(ChatMessage chatMessage) {
            var chatMessageModel = new ChatMessageModel() {
                Id = chatMessage.Id,
                UserName = chatMessage.UserName,
                Text = chatMessage.Text
            };
            _repository.AddChatMessage(chatMessageModel);
        }

        public IEnumerable<ChatMessage> ChatMessages() {
            var chatMessages = _repository.ChatMessages;
            return chatMessages.Select(
                cm =>  new ChatMessage() { Id = cm.Id, Text = cm.Text, UserName = cm.UserName }
            );
        }
    }
}
