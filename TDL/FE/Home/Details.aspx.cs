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
                        txtTieuDe.Text = congViec.TieuDe;
                        txtMoTa.Text = congViec.MoTa;
                        txtNgayHetHan.Text = congViec.NgayHetHan?.ToString("yyyy-MM-dd") ?? "";
                        chkHoanThanh.Checked = congViec.HoanThanh;
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

        // Xử lý sự kiện Lưu thay đổi
        protected async void btnSave_Click(object sender, EventArgs e)
        {
            var maCongViec = Request.QueryString["MaCongViec"];
            if (int.TryParse(maCongViec, out int maCongViecId))
            {
                var congViecDTO = new CongViecDTO
                {
                    MaCongViec = maCongViecId,
                    TieuDe = txtTieuDe.Text,
                    MoTa = txtMoTa.Text,
                    NgayHetHan = DateTime.TryParse(txtNgayHetHan.Text, out DateTime ngayHetHan) ? (DateTime?)ngayHetHan : null,
                    HoanThanh = chkHoanThanh.Checked // Lưu giá trị của checkbox HoanThanh
                };

                var isUpdated = await UpdateCongViecAsync(congViecDTO);
                if (isUpdated)
                {
                    // thành công
                }
                else
                {
                    // Thông báo lỗi
                    Response.Write("<script>alert('Cập nhật công việc thất bại');</script>");
                }
            }
        }


        // Phương thức gọi API để cập nhật công việc
        private async Task<bool> UpdateCongViecAsync(CongViecDTO congViecDTO)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"https://localhost:44341/api/CongViec/Update", congViecDTO);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                // Xử lý lỗi kết nối
                Response.Write("<script>alert('Không thể kết nối với API để cập nhật công việc.');</script>");
                return false;
            }
        }

        // Quay lại trang trước
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home/Index.aspx"); // Điều hướng lại trang danh sách
        }
    }
}
