using BLL;
using System;
using System.Linq;
using System.Windows.Forms;
using UC.UserControls;

namespace GUI
{
    public partial class Frm_main : Form
    {
        private string _tenDangNhap;
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }

        private CongViecBLL congViecBLL = new CongViecBLL();

        public Frm_main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true;

            // Khai báo sự kiện
            this.FormClosed += Frm_main_FormClosed;
            this.Load += Frm_main_Load;
        }

        private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem đã tải công việc chưa, tránh việc tải lại
            if (flp_congViec.Controls.Count == 0)
            {
                // Lấy danh sách công việc của người dùng
                var danhSachCongViec = congViecBLL.GetByTenDangNhap(TenDangNhap);

                // Duyệt qua danh sách công việc và tạo ra các UserControl tương ứng
                foreach (var congViec in danhSachCongViec)
                {
                    Uc_congViec ucCongViec = new Uc_congViec();
                    ucCongViec.TieuDe = congViec.TieuDe;
                    ucCongViec.NgayHetHan = congViec.NgayHetHan.HasValue
                        ? congViec.NgayHetHan.Value.ToString("dd/MM/yyyy")
                        : "Không có hạn";
                    ucCongViec.HoanThanh = congViec.HoanThanh;

                    // Thêm vào FlowLayoutPanel
                    flp_congViec.Controls.Add(ucCongViec);
                }
            }
        }

    }
}
