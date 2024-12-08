<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FE.Home.Index" MasterPageFile="~/Todo.Master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Danh sách công việc</h2>

            <div class="d-flex mb-3">
                <!-- Thanh chọn danh mục chiếm 30% -->
                <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-select me-2" 
                                  AutoPostBack="true" OnSelectedIndexChanged="ddlDanhMuc_SelectedIndexChanged" 
                                  Style="flex: 0 0 10%;">
                </asp:DropDownList>

                <!-- Thanh thêm công việc chiếm 70% -->
                <div class="d-flex" style="flex: 1 0 0;">
                    <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control me-2" Placeholder="Nhập tiêu đề"></asp:TextBox>
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Thêm" OnClick="btnAdd_Click" />
                </div>
            </div>

            <!-- Danh sách công việc -->
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

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
