<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TaskManager.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet">
    <title>LogIn</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblEmail" runat="server" Text="Username / Email" AssociatedControlID="txtEmail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login"  CssClass="btn" BackColor="#0033CC" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <div class="signup-link">
                <asp:HyperLink ID="hlSignUp" runat="server" NavigateUrl="~/SignUp.aspx">Don't have an account? Sign Up</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
