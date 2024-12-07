<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FE.Home.Index" MasterPageFile="~/Todo.Master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Danh sách công việc</h2>

            <!-- Khu vực thêm công việc mới -->
            <div class="mb-3 d-flex">
                <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control me-2" Placeholder="Nhập tiêu đề"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Thêm" OnClick="btnAdd_Click" />
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <!-- Sidebar nằm bên trái với mũi tên điều khiển -->
        <div id="sidebar" class="bg-light border-right">
            <div class="sidebar-heading">Danh mục</div>
            <div class="list-group list-group-flush">
                <asp:Button ID="btnTatCa" runat="server" Text="Tất cả" CssClass="list-group-item list-group-item-action bg-light" OnClick="btnTatCa_Click" />
                <asp:ListView ID="lvDanhMuc" runat="server" OnItemCommand="lvDanhMuc_ItemCommand">
                    <ItemTemplate>
                        <a href="#" class="list-group-item list-group-item-action bg-light" CommandArgument='<%# Eval("MaDanhMuc") %>'>
                            <%# Eval("TenDanhMuc") %> <!-- Hiển thị tên danh mục -->
                        </a>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    
        <!-- Mũi tên điều khiển -->
        <div id="toggleButton" class="sidebar-toggle-btn">
            <span id="toggleIcon" class="fas fa-chevron-right"></span>
        </div>
    </form>
</asp:Content>
