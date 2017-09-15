﻿using System.Collections.Generic;
using System.ServiceModel;
using WcfChat.Contracts.Data;

namespace WcfChat.Contracts {
    [ServiceContract]
    public interface IChatService {
        [OperationContract]
        IEnumerable<ChatMessage> ChatMessages();

        [OperationContract]
        void AddChatMessage(ChatMessage chatMessage);
    }
}
