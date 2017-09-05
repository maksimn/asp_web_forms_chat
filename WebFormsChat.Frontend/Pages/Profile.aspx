<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" 
    Inherits="WebFormsChat.Frontend.Pages.Profile" MasterPageFile="~/Pages/Site.master" %>

<asp:Content ID="Main" runat="server" ContentPlaceHolderID="MainContent">
    <div class="auth-content">
        <h2>Профиль пользователя</h2>

        <form id="UserPreferencesForm" runat="server">
            <div class="auth-form__field">
                ID: <%= UserData.Id %>
            </div>
            <div class="auth-form__field">
                Имя: <%= UserData.Name %>
            </div>

            <div class="auth-form__field">
                Цвет заголовка страницы:

                    <asp:DropDownList ID="HeaderColorPicker" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="OnHeaderColorPickerSelectedIndexChanged">
                        <asp:ListItem>Зеленый</asp:ListItem>
                        <asp:ListItem>Синий</asp:ListItem>
                    </asp:DropDownList>
            </div>

            <div class="auth-form__field">
                <asp:HyperLink runat="server" NavigateUrl="~/Pages/Chat.aspx" Text="На страницу чата" />
            </div>
        </form>

    </div>
</asp:Content>