<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DanhMuc.aspx.cs" Inherits="FE.Home.DanhMuc" MasterPageFile="~/Todo.Master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="formDanhMuc" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Quản lý Danh Mục</h2>

   
            <div class="mb-3">
                <div class="input-group">
                    <asp:TextBox ID="txtTenDanhMuc" runat="server" CssClass="form-control" Placeholder="Nhập tên danh mục"></asp:TextBox>
                    <asp:Button ID="btnAddDanhMuc" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnAddDanhMuc_Click" />
                </div>
            </div>

       
            <div class="table-responsive">
                <asp:GridView ID="gvDanhMuc" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered text-center"
                    OnRowCommand="gvDanhMuc_RowCommand" OnRowDeleting="gvDanhMuc_RowDeleting">
                    <Columns>
                        
                        <asp:BoundField DataField="TenDanhMuc" HeaderText="Tên Danh Mục" />

                  
                        <asp:TemplateField HeaderText="Hành Động">
                            <ItemTemplate>
                                <div class="d-flex justify-content-center">
                                    <asp:Button ID="btnEdit" runat="server" Text="✏ Sửa" CommandName="Edit" CommandArgument='<%# Eval("MaDanhMuc") %>' CssClass="btn btn-sm btn-outline-primary me-2" />
                                    <asp:Button ID="btnDelete" runat="server" Text="🗑 Xóa" CommandName="Delete" CommandArgument='<%# Eval("MaDanhMuc") %>' CssClass="btn btn-sm btn-outline-danger" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
