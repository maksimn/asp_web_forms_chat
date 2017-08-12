<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" 
         Inherits="WebFormsChat.Frontend.Pages.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Чат на ASP.NET</title>
    <link rel="stylesheet" href="~/css/styles.css">
</head>
<body>
    <div>
        <div class="header">
            <h1 class="header__title">ASP.NET чат</h1>
        </div>

        <div class="auth-content">

            <h2>Регистрация пользователя</h2>

            <form id="RegistrationForm" runat="server">

                <div class="auth-form__field">
                    <div>Имя: </div>
                    <div>
                        <asp:TextBox id="UserName" runat="server" />
                    </div>
                </div>
                <div class="auth-form__field">
                    <div>Пароль: </div>
                    <div>
                        <asp:TextBox id="Password" TextMode="Password" runat="server" />
                    </div>
                </div>
                <div class="auth-form__field">
                    <div>Повтор пароля: </div>
                    <div>
                        <asp:TextBox id="ConfirmPassword" TextMode="Password" runat="server" />
                    </div>
                </div>

                <div class="validation-errors">
                    <div class="validation-errors__error">
                        <asp:RequiredFieldValidator runat="server" id="UserNameValidation"
                            Display="Dynamic"
                            ControlToValidate="UserName" 
                            ErrorMessage="* Имя должно быть заполнено" />
                    </div>
                    <div class="validation-errors__error">
                        <asp:RequiredFieldValidator runat="server" id="PasswordValidation" 
                            Display="Dynamic"
                            ControlToValidate="Password" 
                            ErrorMessage="* Пароль должен быть заполнен" />
                        </div>
                    <div class="validation-errors__error">
                        <asp:RequiredFieldValidator runat="server" id="ConfirmPasswordValidation"
                            Display="Dynamic"
                            ControlToValidate="ConfirmPassword" 
                            ErrorMessage="* Повтор пароля должен быть заполнен" />
                    </div>
                    <div class="validation-errors__error">
                        <asp:CompareValidator runat="server" id="ConfirmPasswordEqualToPasswordValidation" 
                            Display="Dynamic"
                            ControlToValidate="Password"
                            ControlToCompare="ConfirmPassword"
                            Operator="Equal"
                            Type="String"
                            ErrorMessage="* Пароль и его повтор должны совпадать" />
                    </div>
                    <div class="validation-errors__error">
                        <asp:CustomValidator runat="server" id="UserNameDuplicationValidation"
                            Display="Dynamic" 
                            ControlToValidate="UserName" 
                            OnServerValidate="CheckUserNameDuplication"
                            ErrorMessage="* Пользователь с данным именем уже существует. Попробуйте другое имя." />
                    </div>
                </div>

                <div class="auth-form__field">
                    <asp:Button runat="server" Text="Зарегистрироваться" OnClick="SubmitHandler" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
