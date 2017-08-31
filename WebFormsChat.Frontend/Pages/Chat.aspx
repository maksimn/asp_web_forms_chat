<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" 
    MasterPageFile="~/Pages/Site.master" Inherits="WebFormsChat.Frontend.Pages.Chat" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <div class="header__username">
        <form runat="server">
            <%= User.Identity.Name %>
            <span class="header__logout-button">
                <asp:Button runat="server" Text="Выйти" OnClick="SignOutHandler" />
            </span>
        </form>
    </div>
</asp:Content>

<asp:Content ID="Main" runat="server" ContentPlaceHolderID="MainContent">
    <div class="chat-room">

        <div class="chat-room__header"></div>

        <div class="chat-room__chat-messages">
            <% 
                foreach(var message in ChatService.ChatMessages) {
            %>
                    <div class="chat-message">
                        <div class="chat-message__username">
                            <%= message.UserName %>
                        </div>
                        <div class="chat-message__text">
                            <%= message.Text %>
                        </div>
                    </div>
            <%
                }
            %>
        </div>

        <div class="chat-room__chat-message-input">
            <textarea
                id="chatMessageInput"
                class="chat-message-input__textbox"
                maxlength="500"
                placeholder="Напишите сообщение..."></textarea>
        </div>
    </div>
    <script>
        window.onload = function () {
            var host = window.location.host;
            var socket = new WebSocket('ws://' + host + '/HttpHandlers/ChatHandler.ashx');

            var chatMessages = document.querySelector('.chat-room__chat-messages');
            var chatMessageInput = document.getElementById('chatMessageInput');

            chatMessageInput.onkeypress = function (e) {
                if (e.key === 'Enter') {
                    var chatMessage = {
                        UserName: <%= User.Identity.Name %>,
                        Text: e.target.value
                    };
                    socket.send(JSON.stringify(chatMessage));
                }
            };

            chatMessageInput.onkeyup = function (e) {
                if (e.key === 'Enter') {
                    e.target.value = '';
                }
            };

            socket.onmessage = function (msg) {
                var trimChatMessage = msg.data.replace(/\0/g, '');
                var chatMessageObject = JSON.parse(trimChatMessage);

                var chatMessage = document.createElement('div');
                chatMessage.className = 'chat-message';
                chatMessage.innerHTML = '<div class="chat-message__username">' + 
                    chatMessageObject.UserName + '</div><div class="chat-message__text">' + 
                    chatMessageObject.Text + '</div>';

                chatMessages.appendChild(chatMessage);
            };

            socket.onclose = function () {
                alert('Соединение закрыто.');
            }

            socket.onerror = function () {
                alert('Произошла ошибка соединения с чатом.');
            };
        };
    </script>
</asp:Content>