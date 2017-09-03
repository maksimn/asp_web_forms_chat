window.addEventListener('load', function () {
    var isScrolledFromBottomPos = false;
    var chatMessages = document.querySelector('.chat-room__chat-messages');

    chatMessages.addEventListener('scroll', scrollHandler, false);
    setInterval(updateScroll, 300);

    function scrollHandler() {
        isScrolledFromBottomPos =
            chatMessages.clientHeight + chatMessages.scrollTop !== chatMessages.scrollHeight;
    }

    function updateScroll() {
        if (!isScrolledFromBottomPos) {
            chatMessages.scrollTop = chatMessages.scrollHeight;
        }
    }
}, false);