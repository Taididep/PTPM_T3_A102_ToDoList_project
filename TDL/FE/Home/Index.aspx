<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FE.Home.Index" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách công việc</title>
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <style>
        .table td, .table th {
            vertical-align: middle;
        }

        /* Cột chứa các nút Sửa và Xóa chỉ chiếm 1% chiều rộng */
        .action-column {
            width: 1% !important;
            white-space: nowrap; /* Đảm bảo nội dung không bị xuống dòng */
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Danh sách công việc</h2>
            <div class="table-responsive">
                <asp:GridView ID="gvCongViec" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    OnRowCommand="gvCongViec_RowCommand" HeaderStyle-CssClass="d-none" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="action-column">
                            <ItemTemplate>
                                <div class="d-flex align-items-center justify-content-center">
                                    <asp:CheckBox ID="chkHoanThanh" runat="server" CssClass="form-check-input" 
                                                  Checked='<%# Convert.ToBoolean(Eval("HoanThanh")) %>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex flex-column align-items-start">
                                    <span class="fw-bold"><%# Eval("TieuDe") %></span>
                                    <small class="text-muted">Hạn: <%# String.Format("{0:dd-MM-yyyy}", Eval("NgayHetHan")) %></small>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="action-column">
                            <ItemTemplate>
                                <asp:Button ID="btnDetail" runat="server" Text="✏" CommandName="Detail" 
                                            CommandArgument='<%# Eval("MaCongViec") %>' CssClass="btn btn-sm btn-outline-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField ItemStyle-CssClass="action-column">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="🗑" CommandName="Delete" 
                                            CommandArgument='<%# Eval("MaCongViec") %>' CssClass="btn btn-sm btn-outline-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
