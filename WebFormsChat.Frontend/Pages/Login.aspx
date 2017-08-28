<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" 
    MasterPageFile="~/Pages/Site.master" Inherits="WebFormsChat.Frontend.Pages.Login" %>

<asp:Content ID="Main" runat="server" ContentPlaceHolderID="MainContent">
    <div class="auth-content">
        <h2>Вход в систему</h2>

        <form id="LoginForm" runat="server">

            <div class="auth-form__field">
                <div>Имя: </div>
                <div>
                    <asp:TextBox ID="UserName" runat="server" />
                </div>
            </div>
            <div class="auth-form__field">
                <div>Пароль: </div>
                <div>
                    <asp:TextBox ID="Password" TextMode="Password" runat="server" />
                </div>
            </div>

            <div class="validation-errors">
                <div class="validation-errors__error">
                    <asp:RequiredFieldValidator runat="server" ID="UserNameValidation"
                        Display="Dynamic"
                        ControlToValidate="UserName"
                        ErrorMessage="* Имя должно быть заполнено" />
                </div>
                <div class="validation-errors__error">
                    <asp:RequiredFieldValidator runat="server" ID="PasswordValidation"
                        Display="Dynamic"
                        ControlToValidate="Password"
                        ErrorMessage="* Пароль должен быть заполнен" />
                </div>
                <div class="validation-errors__error">
                    <asp:CustomValidator runat="server" ID="LoginDataValidation"
                        Display="Dynamic"
                        ControlToValidate=""
                        ErrorMessage="* Неверное имя или пароль." />
                </div>
            </div>

            <div class="auth-form__field">
                <asp:Button runat="server" Text="Войти" OnClick="SubmitHandler" />
            </div>

            <div class="auth-form__field">
                <asp:HyperLink runat="server" NavigateUrl="~/Pages/Register.aspx" Text="Регистрация" />
            </div>
        </form>
    </div>
</asp:Content>