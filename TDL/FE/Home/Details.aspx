<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FE.Home.Details" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết công việc</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Chi tiết công việc</h2>
            <asp:Label ID="lblTieuDe" runat="server" Text="Tiêu đề: " Font-Bold="True"></asp:Label><br />
            <asp:Label ID="lblTieuDeContent" runat="server"></asp:Label><br /><br />

            <asp:Label ID="lblMoTa" runat="server" Text="Mô tả: " Font-Bold="True"></asp:Label><br />
            <asp:Label ID="lblMoTaContent" runat="server"></asp:Label><br /><br />

            <asp:Label ID="lblNgayHetHan" runat="server" Text="Ngày hết hạn: " Font-Bold="True"></asp:Label><br />
            <asp:Label ID="lblNgayHetHanContent" runat="server"></asp:Label><br /><br />

            <asp:Label ID="lblHoanThanh" runat="server" Text="Hoàn thành: " Font-Bold="True"></asp:Label><br />
            <asp:Label ID="lblHoanThanhContent" runat="server"></asp:Label><br /><br />

            <asp:Button ID="btnBack" runat="server" Text="Quay lại" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
