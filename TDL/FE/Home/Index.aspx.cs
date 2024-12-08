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
                    await LoadDanhMucAsync(tenDangNhap);
                    await LoadDataAsync(tenDangNhap);
                }
            }
        }

        private async Task LoadDataAsync(string tenDangNhap, int? maDanhMuc = null)
        {
            try
            {
                var url = maDanhMuc.HasValue ?
                    $"https://localhost:44341/api/CongViec/GetByTenDangNhapAndDanhMuc/{maDanhMuc.Value}/{tenDangNhap}" :
                    $"https://localhost:44341/api/CongViec/GetByTenDangNhap/{tenDangNhap}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var congViecs = await response.Content.ReadAsAsync<List<CongViecDTO>>();
                    gvCongViec.DataSource = congViecs;
                    gvCongViec.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Không thể lấy dữ liệu công việc!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
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
                    ddlDanhMuc.DataSource = danhMucs;
                    ddlDanhMuc.DataTextField = "TenDanhMuc";
                    ddlDanhMuc.DataValueField = "MaDanhMuc";
                    ddlDanhMuc.DataBind();

                    ddlDanhMuc.Items.Insert(0, new ListItem("Tất cả", "0"));
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

        protected async void ddlDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tenDangNhap = Session["TenDangNhap"] as string;
            int maDanhMuc = Convert.ToInt32(ddlDanhMuc.SelectedValue);

            if (maDanhMuc > 0)
            {
                await LoadDataAsync(tenDangNhap, maDanhMuc);
            }
            else
            {
                await LoadDataAsync(tenDangNhap);
            }
        }


        protected void gvCongViec_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                string maCongViec = e.CommandArgument.ToString();
                Response.Redirect($"/Home/Details.aspx?MaCongViec={maCongViec}", false);
            }
            else if (e.CommandName == "Delete")
            {
                string maCongViec = e.CommandArgument.ToString();

                // Xử lý xóa công việc
                Task.Run(async () =>
                {
                    await DeleteCongViecAsync(maCongViec);
                    var tenDangNhap = Session["TenDangNhap"] as string;
                    await LoadDataAsync(tenDangNhap); // Tải lại danh sách sau khi xóa
                }).GetAwaiter().GetResult();
            }
        }

        private async Task DeleteCongViecAsync(string maCongViec)
        {
            try
            {
                var url = $"https://localhost:44341/api/CongViec/Delete/{maCongViec}";
                var response = await client.DeleteAsync(url);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }

        protected async void btnAdd_Click(object sender, EventArgs e)
        {
            var tieuDe = txtTieuDe.Text.Trim();

            if (!string.IsNullOrEmpty(tieuDe))
            {
                var tenDangNhap = Session["TenDangNhap"] as string;

                var congViec = new CongViecDTO
                {
                    TenDangNhap = tenDangNhap,
                    TieuDe = tieuDe
                };

                try
                {
                    var url = "https://localhost:44341/api/CongViec/Insert";
                    var response = await client.PostAsJsonAsync(url, congViec);

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadDataAsync(tenDangNhap);
                        txtTieuDe.Text = string.Empty; // Xóa nội dung TextBox sau khi thêm
                    }
                    else
                    {
                        Response.Write("<script>alert('Thêm công việc không thành công!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Tiêu đề không được để trống!');</script>");
            }
        }

        protected void gvCongViec_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Không cần xử lý gì trong sự kiện này, chỉ cần không để xảy ra lỗi.
        }


        protected async void chkHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            var chkHoanThanh = (CheckBox)sender;

            // Lấy MaCongViec từ Attributes
            int maCongViec = Convert.ToInt32(chkHoanThanh.Attributes["CommandArgument"]);
            bool hoanThanh = chkHoanThanh.Checked;

            // Gọi API PUT để cập nhật trạng thái
            try
            {
                var url = $"https://localhost:44341/api/CongViec/UpdateHoanThanh/{maCongViec}/{hoanThanh}";
                var response = await client.PutAsJsonAsync(url, new { HoanThanh = hoanThanh });

                if (response.IsSuccessStatusCode)
                {
                    // Cập nhật thành công, reload dữ liệu
                    var tenDangNhap = Session["TenDangNhap"] as string;
                    await LoadDataAsync(tenDangNhap);
                }
                else
                {
                    Response.Write("<script>alert('Không thể cập nhật trạng thái công việc!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi: {ex.Message}');</script>");
            }
        }


    }
}
