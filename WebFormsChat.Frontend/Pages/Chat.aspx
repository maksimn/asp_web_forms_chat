﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" 
    MasterPageFile="~/Pages/Site.master" Inherits="WebFormsChat.Frontend.Pages.Chat" %>

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
                class="chat-message-input__textbox"
                maxlength="500"
                placeholder="Напишите сообщение...">
            </textarea>
        </div>
    </div>
</asp:Content>