using DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;

namespace FE.Home
{
    public partial class Details : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy giá trị MaCongViec từ query string
                var maCongViec = Request.QueryString["MaCongViec"];

                if (int.TryParse(maCongViec, out int maCongViecId))
                {
                    // Gọi API để lấy chi tiết công việc
                    CongViecDTO congViec = await GetCongViecByIdAsync(maCongViecId);

                    if (congViec != null)
                    {
                        // Hiển thị thông tin công việc lên trang
                        lblTieuDeContent.Text = congViec.TieuDe;
                        lblMoTaContent.Text = congViec.MoTa;
                        lblNgayHetHanContent.Text = congViec.NgayHetHan?.ToString("dd/MM/yyyy") ?? "Chưa có ngày hết hạn";
                        lblHoanThanhContent.Text = congViec.HoanThanh ? "Đã hoàn thành" : "Chưa hoàn thành";
                    }
                    else
                    {
                        // Trường hợp không tìm thấy công việc
                        Response.Write("<script>alert('Công việc không tồn tại');</script>");
                    }
                }
                else
                {
                    // Trường hợp không hợp lệ, không tìm thấy MaCongViec
                    Response.Write("<script>alert('Mã công việc không hợp lệ');</script>");
                }
            }
        }

        private async Task<CongViecDTO> GetCongViecByIdAsync(int maCongViec)
        {
            try
            {
                // Gọi API để lấy công việc theo MaCongViec
                var response = await client.GetAsync($"https://localhost:44341/api/CongViec/GetByID/{maCongViec}");

                // Nếu trả về kết quả OK, parse response thành CongViecDTO
                if (response.IsSuccessStatusCode)
                {
                    var congViec = await response.Content.ReadAsAsync<CongViecDTO>();
                    return congViec;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi kết nối
                Response.Write("<script>alert('Không thể kết nối với API.');</script>");
                return null;
            }
        }

        // Quay lại trang trước
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home/Index.aspx"); // Điều hướng lại trang danh sách
        }
    }
}
