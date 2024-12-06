<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FE.WebForm1" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <h2>Đăng Nhập</h2>
        <label for="txtUsername">Tên đăng nhập:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <label for="txtPassword">Mật khẩu:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
    </div>
</form>
</body>
</html>
