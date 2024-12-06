using DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FE.Home
{
    public partial class Index : System.Web.UI.Page
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
                    await LoadDataAsync(tenDangNhap);
                }
            }
        }

        private async Task LoadDataAsync(string tenDangNhap)
        {
            try
            {
                var url = $"https://localhost:44341/api/CongViec/GetByTenDangNhap/{tenDangNhap}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var congViecs = await response.Content.ReadAsAsync<List<CongViecDTO>>();
                    gvCongViec.DataSource = congViecs;
                    gvCongViec.DataBind();
                }
                else
                {
                    // Thêm xử lý lỗi nếu không lấy được dữ liệu
                    Response.Write("<script>alert('Không thể lấy dữ liệu công việc!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }

        protected async void gvCongViec_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Kiểm tra CommandName là "Detail"
            if (e.CommandName == "Detail")
            {
                // Lấy giá trị MaCongViec từ CommandArgument
                string maCongViec = e.CommandArgument.ToString();

                // Chuyển hướng tới trang chi tiết với MaCongViec
                Response.Redirect($"/Home/Details.aspx?MaCongViec={maCongViec}", false);
            }
            // Kiểm tra CommandName là "Delete"
            else if (e.CommandName == "Delete")
            {
                // Lấy MaCongViec từ CommandArgument khi xóa
                string maCongViec = e.CommandArgument.ToString();

                // Gọi hàm xóa
                await DeleteCongViecAsync(maCongViec);

                // Tải lại dữ liệu sau khi xóa
                await LoadDataAsync(Session["TenDangNhap"] as string);
            }
        }


        private async Task DeleteCongViecAsync(string maCongViec)
        {
            try
            {
                var url = $"https://localhost:44341/api/CongViec/Delete/{maCongViec}";
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Xóa thành công
                }
                else
                {
                    Response.Write("<script>alert('Xóa không thành công!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }
    }
}
