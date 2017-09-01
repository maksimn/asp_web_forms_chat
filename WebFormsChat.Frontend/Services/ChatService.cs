using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;
using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Frontend.Services {
    public class ChatService : IChatService {
        private IMessageRepository repository;

        private static List<WebSocket> webSockets = new List<WebSocket>();
        private const int MSG_BUFFER_SIZE = 1000;

        private static readonly object _lock = new object();

        public ChatService(IMessageRepository messageRepository) {
            repository = messageRepository;
        }

        public async Task WebSocketChatMessages(AspNetWebSocketContext context) {
            var socket = context.WebSocket;
            Monitor.Enter(_lock);
            webSockets.Add(socket);
            Monitor.Exit(_lock);

            // Listening this socket
            while (socket.State == WebSocketState.Open) {
                var receiveBuffer = new ArraySegment<byte>(new byte[MSG_BUFFER_SIZE]);

                // Waiting data from the socket
                var receiveResult = await socket.ReceiveAsync(receiveBuffer, CancellationToken.None);

                var stringResult = BufferToString(receiveBuffer, receiveResult.Count);

                AddChatMessageToStorage(stringResult);

                // Send the message to clients
                await SendChatMessageToAll(stringResult);
            }
            // Connection closed. Remove this socket.
            Monitor.Enter(_lock);
            webSockets.Remove(socket);
            Monitor.Exit(_lock);
        }

        private static async Task SendChatMessageToAll(string message) {
            var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            foreach (var webSocket in webSockets) {
                if (webSocket.State == WebSocketState.Open) {
                    await webSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true,
                        CancellationToken.None);
                }
            }
        }

        private void AddChatMessageToStorage(string str) {
            var chatMessage = JsonConvert.DeserializeObject<ChatMessage>(str);
            if (chatMessage != null) {
                repository.AddChatMessage(chatMessage);
            }
        }

        private string BufferToString(ArraySegment<byte> buffer, int count) {
            return Encoding.UTF8.GetString(buffer.Array, 0, count);
        }

        public IEnumerable<ChatMessage> ChatMessages {
            get {
                return repository.ChatMessages;
            }
        }
    }
}