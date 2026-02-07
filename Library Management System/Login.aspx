<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="Library_Management_System.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>

<body>

    <!-- THIS FORM IS REQUIRED -->
    <form id="form1" runat="server">

        <div class="login-wrapper">
            <div class="login-card">

                <h2 class="login-title">Library Login</h2>
                <p class="login-subtitle">Welcome back 👋</p>

                <div class="input-group">
                    <asp:TextBox ID="txtUsername" runat="server"
                        CssClass="login-input"
                        placeholder="Username"></asp:TextBox>
                </div>

                <div class="input-group">
                    <asp:TextBox ID="txtPassword" runat="server"
                        CssClass="login-input"
                        TextMode="Password"
                        placeholder="Password"></asp:TextBox>
                </div>

                <asp:Button ID="btnLogin" runat="server"
                    Text="Log In"
                    CssClass="login-btn"
                    OnClick="btnLogin_Click" />

                <asp:Label ID="lblMessage" runat="server"
                    CssClass="login-error"></asp:Label>

            </div>
        </div>

    </form>
</body>
</html>
