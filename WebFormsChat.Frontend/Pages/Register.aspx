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

                <%-- <ValidationErrors /> --%>

                <div class="auth-form__field">
                    <asp:Button runat="server" Text="Зарегистрироваться" OnClick="SubmitHandler" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
