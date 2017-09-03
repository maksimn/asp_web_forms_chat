window.addEventListener('load', function () {
    var host = window.location.host;
    var socket = new WebSocket('ws://' + host + '/HttpHandlers/ChatHandler.ashx');
    var chatMessages = document.querySelector('.chat-room__chat-messages');
    var chatMessageInput = document.getElementById('chatMessageInput');

    chatMessageInput.onkeypress = function (e) {
        if (e.key === 'Enter') {
            var chatMessage = {
                UserName: globalUserName,
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
}, false);