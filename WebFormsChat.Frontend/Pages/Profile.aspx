<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" 
    Inherits="WebFormsChat.Frontend.Pages.Profile" MasterPageFile="~/Pages/Site.master" %>

<asp:Content ID="Main" runat="server" ContentPlaceHolderID="MainContent">
    <div class="auth-content">
        <h2>Профиль пользователя</h2>

        <form id="UserPreferencesForm" runat="server">
            <div class="auth-form__field">
                <div>ID: <%= UserData.Id %></div>
            </div>
            <div class="auth-form__field">
                <div>Имя: <%= UserData.Name %></div>
            </div>

            <div class="auth-form__field">
                <asp:HyperLink runat="server" NavigateUrl="~/Pages/Chat.aspx" Text="На страницу чата" />
            </div>
        </form>

    </div>
</asp:Content>