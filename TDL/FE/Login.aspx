<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FE.WebForm1" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-start" style="height: 100vh; padding-top: 150px;">
            <div class="card shadow-lg p-4" style="width: 100%; max-width: 400px; border-radius: 10px;">
                <h2 class="text-center mb-4">Đăng Nhập</h2>
                <div class="form-group">
                    <label for="txtUsername">Tên đăng nhập:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Nhập tên đăng nhập"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Mật khẩu:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Nhập mật khẩu"></asp:TextBox>
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block text-center"></asp:Label>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
