using DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FE.Home
{
    public partial class DanhMuc : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var tenDangNhap = Session["TenDangNhap"] as string;
                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    Response.Redirect("/Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    await LoadDanhMucAsync(tenDangNhap); // Đảm bảo await được sử dụng trong phương thức bất đồng bộ
                }
            }
        }


        private async Task LoadDanhMucAsync(string tenDangNhap)
        {
            try
            {
                var url = $"https://localhost:44341/api/DanhMuc/GetByTenDangNhap/{tenDangNhap}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var danhMucs = await response.Content.ReadAsAsync<List<DanhMucDTO>>();
                    gvDanhMuc.DataSource = danhMucs;
                    gvDanhMuc.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Không thể tải danh mục!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }

        protected async void btnAddDanhMuc_Click(object sender, EventArgs e)
        {
            var tenDanhMuc = txtTenDanhMuc.Text.Trim();
            var tenDangNhap = Session["TenDangNhap"] as string;

            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                Response.Write("<script>alert('Tên danh mục không được để trống!');</script>");
                return;
            }

            var danhMuc = new DanhMucDTO
            {
                TenDangNhap = tenDangNhap,
                TenDanhMuc = tenDanhMuc
            };

            try
            {
                var url = "https://localhost:44341/api/DanhMuc/Insert";
                var response = await client.PostAsJsonAsync(url, danhMuc);

                if (response.IsSuccessStatusCode)
                {
                    await LoadDanhMucAsync(tenDangNhap);
                    txtTenDanhMuc.Text = string.Empty; // Xóa TextBox sau khi thêm
                }
                else
                {
                    Response.Write("<script>alert('Thêm danh mục không thành công!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }


        protected async void gvDanhMuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var tenDangNhap = Session["TenDangNhap"] as string;

            if (e.CommandName == "Delete")
            {
                var maDanhMuc = Convert.ToInt32(e.CommandArgument);
                var url = $"https://localhost:44341/api/DanhMuc/Delete/{maDanhMuc}";

                try
                {
                    var response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadDanhMucAsync(tenDangNhap);
                    }
                    else
                    {
                        Response.Write("<script>alert('Xóa danh mục không thành công!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
                }
            }
        }

        protected void gvDanhMuc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Không cần xử lý tại đây
        }
    }
}
