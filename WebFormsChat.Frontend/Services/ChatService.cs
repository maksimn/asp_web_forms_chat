using System;
using System.Collections.Generic;
using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Frontend.Services {
    public class ChatService : IChatService {
        private IMessageRepository repository;

        public ChatService(IMessageRepository messageRepository) {
            repository = messageRepository;
        }

        public IEnumerable<ChatMessage> ChatMessages {
            get {
                return repository.ChatMessages;
            }
        }
    }
}