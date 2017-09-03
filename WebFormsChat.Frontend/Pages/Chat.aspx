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
                foreach(var message in ChatMessages) {
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
        var globalUserName = <%= User.Identity.Name %>;
    </script>
    <script src="/Pages/scripts/chatMessagesScroll.js"></script>
    <script src="/Pages/scripts/chatWebSockets.js"></script>
</asp:Content>