using DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
                var maCongViec = Request.QueryString["MaCongViec"];

                if (int.TryParse(maCongViec, out int maCongViecId))
                {
                    // Lấy chi tiết công việc
                    CongViecDTO congViec = await GetCongViecByIdAsync(maCongViecId);

                    if (congViec != null)
                    {
                        // Hiển thị thông tin công việc lên trang
                        txtTieuDe.Text = congViec.TieuDe;
                        txtMoTa.Text = congViec.MoTa;
                        txtNgayHetHan.Text = congViec.NgayHetHan?.ToString("yyyy-MM-dd") ?? "";
                        chkHoanThanh.Checked = congViec.HoanThanh;

                        // Lấy danh mục của công việc
                        var danhMucList = await GetDanhMucByMaCongViecAsync(maCongViecId);
                        DisplayDanhMuc(danhMucList);
                    }
                    else
                    {
                        Response.Write("<script>alert('Công việc không tồn tại');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Mã công việc không hợp lệ');</script>");
                }
            }
        }

        // Hiển thị danh mục lên điều khiển Literal
        private void DisplayDanhMuc(List<DanhMucDTO> danhMucList)
        {
            var danhMucHtml = new StringBuilder(); // Dùng StringBuilder để nối chuỗi HTML

            foreach (var item in danhMucList)
            {
                // Tạo một button cho mỗi danh mục
                danhMucHtml.Append($"<button class='btn btn-outline-primary m-1' type='button'>{HttpUtility.HtmlEncode(item.TenDanhMuc)}</button>");
            }

            // Đặt HTML vào Literal để hiển thị trên trang
            litDanhMuc.Text = danhMucHtml.ToString();
        }

        private async Task<List<DanhMucDTO>> GetDanhMucByMaCongViecAsync(int maCongViec)
        {
            try
            {
                // Gọi API để lấy danh mục theo MaCongViec
                var response = await client.GetAsync($"https://localhost:44341/api/CongViecDanhMuc/GetByMaCongViec/{maCongViec}");

                // Nếu trả về kết quả OK, parse response thành List<DanhMucDTO>
                if (response.IsSuccessStatusCode)
                {
                    var danhMucList = await response.Content.ReadAsAsync<List<DanhMucDTO>>();
                    return danhMucList;
                }
                else
                {
                    return new List<DanhMucDTO>(); // Nếu không có dữ liệu, trả về danh sách rỗng
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                Response.Write("<script>alert('Không thể kết nối với API để lấy danh mục.');</script>");
                return new List<DanhMucDTO>(); // Trả về danh sách rỗng trong trường hợp lỗi
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
