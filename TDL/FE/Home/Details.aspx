<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FE.Home.Details" MasterPageFile="~/Todo.Master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">Chi tiết công việc</h2>

            <!-- Tiêu đề, ngày hết hạn và checkbox Hoàn thành, tách thành ba cột -->
            <div class="row align-items-stretch">
                <div class="col-md-8">
                    <!-- Khung bên trái cho Tiêu đề -->
                    <div class="note">
                        <div class="note-header h-100 d-flex align-items-center">
                            <asp:TextBox ID="txtTieuDe" TextMode="MultiLine" Rows="1" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="col-auto">
                    <!-- Khung giữa cho Ngày hết hạn -->
                    <div class="note">
                        <div class="note-header h-100 d-flex align-items-center">
                            <asp:TextBox ID="txtNgayHetHan" runat="server" CssClass="form-control" type="date" />
                        </div>
                    </div>
                </div>

               <div class="col-auto">
                    <!-- Khung bên phải cho Checkbox Hoàn thành -->
                    <div class="note d-flex justify-content-center align-items-center" style="height: 72px">
                        <label>Hoàn thành &nbsp</label>
                        <div class="d-flex justify-content-center align-items-center">
                            <asp:CheckBox ID="chkHoanThanh" runat="server" CssClass="chk"/>
                        </div>
                    </div>
                </div>
            </div>


            <!-- Mô tả công việc trong ô vuông -->
            <div class="note mt-2">
                <div class="note-body">
                    <asp:TextBox ID="txtMoTa" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Text='<%# Eval("MoTa") %>' />
                </div>
            </div>

            <!-- Nút Lưu và Nút Quay lại -->
            <div class="d-flex justify-content-between mt-4">
                <asp:Button ID="btnBack" runat="server" Text="Quay lại" OnClick="btnBack_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi" OnClick="btnSave_Click" CssClass="btn btn-success me-2" />
            </div>
        </div>
    </form>
</asp:Content>
