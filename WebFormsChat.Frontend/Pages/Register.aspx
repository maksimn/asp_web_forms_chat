<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" 
    MasterPageFile="~/Pages/Site.master" Inherits="WebFormsChat.Frontend.Pages.Register" %>

<asp:Content ID="Main" runat="server" ContentPlaceHolderID="MainContent">
    <div class="auth-content">
        <h2>Регистрация пользователя</h2>

        <form id="RegistrationForm" runat="server">

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
            <div class="auth-form__field">
                <div>Повтор пароля: </div>
                <div>
                    <asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server" />
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
                    <asp:RequiredFieldValidator runat="server" ID="ConfirmPasswordValidation"
                        Display="Dynamic"
                        ControlToValidate="ConfirmPassword"
                        ErrorMessage="* Повтор пароля должен быть заполнен" />
                </div>
                <div class="validation-errors__error">
                    <asp:CompareValidator runat="server" ID="ConfirmPasswordEqualToPasswordValidation"
                        Display="Dynamic"
                        ControlToValidate="Password"
                        ControlToCompare="ConfirmPassword"
                        Operator="Equal"
                        Type="String"
                        ErrorMessage="* Пароль и его повтор должны совпадать" />
                </div>
                <div class="validation-errors__error">
                    <asp:CustomValidator runat="server" ID="UserNameDuplicationValidation"
                        Display="Dynamic"
                        ControlToValidate="UserName"
                        ErrorMessage="* Пользователь с данным именем уже существует. Попробуйте другое имя." />
                </div>
            </div>

            <div class="auth-form__field">
                <asp:Button runat="server" Text="Зарегистрироваться" OnClick="SubmitHandler" />
            </div>

            <div class="auth-form__field">
                <asp:HyperLink runat="server" NavigateUrl="~/Pages/Login.aspx" Text="На страницу входа в систему" />
            </div>
        </form>
    </div>
    <script>
        var isRegistrationSuccess = <%=IsRegisterSuccess %>;
        var didRegistrationErrorHappen = <%=DidRegistrationErrorHappen%>;

        if (isRegistrationSuccess) {
            alert('Новый пользователь успешно зарегистрирован.');
            window.location.href = '/Pages/Login.aspx';
        } else if (didRegistrationErrorHappen) {
            alert('При регистрации произошла ошибка. Попробуйте снова.');
        }
    </script>
</asp:Content>