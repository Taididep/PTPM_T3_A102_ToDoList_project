<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FE.Home.Index" MasterPageFile="~/Todo.Master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Danh sách công việc</h2>

            <div class="d-flex mb-3">
                <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-select me-2" 
                                  AutoPostBack="true" OnSelectedIndexChanged="ddlDanhMuc_SelectedIndexChanged" 
                                  Style="flex: 0 0 10%;"></asp:DropDownList>

                <div class="d-flex" style="flex: 1 0 0;">
                    <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control me-2" Placeholder="Nhập tiêu đề"></asp:TextBox>
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Thêm" OnClick="btnAdd_Click" />
                </div>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="gvCongViec" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    OnRowCommand="gvCongViec_RowCommand" OnRowDeleting="gvCongViec_RowDeleting" HeaderStyle-CssClass="d-none" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="action-column" ItemStyle-Width="1%">
                            <ItemTemplate>
                                <div class="d-flex">
                                    <asp:CheckBox ID="chkHoanThanh" runat="server" CssClass="chk"
                                                  Checked='<%# Convert.ToBoolean(Eval("HoanThanh")) %>' 
                                                  OnCheckedChanged="chkHoanThanh_CheckedChanged" AutoPostBack="true" 
                                                  CommandArgument='<%# Eval("MaCongViec") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex flex-column align-items-start">
                                    <span class="fw-bold"><%# Eval("TieuDe") %></span>
                                    <small class="text-muted"><%# String.Format("{0:dd-MM-yyyy}", Eval("NgayHetHan")) %></small>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="action-column" ItemStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Button ID="btnDetail" runat="server" Text="✏" CommandName="Detail" 
                                            CommandArgument='<%# Eval("MaCongViec") %>' CssClass="btn btn-sm btn-outline-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="action-column" ItemStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="🗑" CommandName="Delete" 
                                            CommandArgument='<%# Eval("MaCongViec") %>' CssClass="btn btn-sm btn-outline-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>




                        <asp:TemplateField ItemStyle-CssClass="action-column" ItemStyle-Width="1%">
                            <ItemTemplate>
                                <asp:Button ID="btnAddDanhMuc" runat="server" Text="📝" CommandName="AddDanhMuc" 
                                            CommandArgument='<%# Eval("MaCongViec") %>' CssClass="btn btn-sm btn-outline-primary"
                                            OnClientClick='<%# "showModal(this); return false;" %>'
                                            data-ma-cong-viec='<%# Eval("MaCongViec") %>' />

                            </ItemTemplate>
                        </asp:TemplateField>







                    </Columns>
                </asp:GridView>
            </div>
        </div>



<div class="modal fade" id="addDanhMucModal" tabindex="-1" role="dialog" aria-labelledby="addDanhMucModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addDanhMucModalLabel">Thêm/Xóa Danh Mục</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:DropDownList ID="ddlDanhMucModal" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:HiddenField ID="hfMaCongViec" runat="server" />
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveDanhMuc" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="btnSaveDanhMuc_Click" />
                <asp:Button ID="btnDeleteDanhMuc" runat="server" CssClass="btn btn-danger" Text="Xóa" OnClick="btnDeleteDanhMuc_Click" />
            </div>
        </div>
    </div>
</div>


    </form>

        <script>
            function showModal(button) {
                const maCongViec = button.getAttribute("data-ma-cong-viec");
                if (!maCongViec || isNaN(maCongViec)) {
                    alert("Mã công việc không hợp lệ!");
                    return;
                }
                document.getElementById("<%= hfMaCongViec.ClientID %>").value = maCongViec;
                $('#addDanhMucModal').modal('show');
            }
        </script>

</asp:Content>
