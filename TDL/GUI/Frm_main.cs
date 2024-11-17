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

            flp_congViec.AutoScroll = true;


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
            LoadDanhMuc();

            LoadTatCaCongViec();
        }



        private void LoadDanhMuc()
        {
            // Hiển thị danh sách danh mục
            DanhMucBLL danhMucBLL = new DanhMucBLL();
            var danhSachDanhMuc = danhMucBLL.GetByTenDangNhap(TenDangNhap);

            // Xóa các nút danh mục cũ (nếu có)
            flp_danhMuc.Controls.Clear();

            // Thêm nút "Tất cả"
            AddButtonTatCa();

            // Tạo nút cho mỗi danh mục
            foreach (var danhMuc in danhSachDanhMuc)
            {
                AddButtonDanhMuc(danhMuc.TenDanhMuc, danhMuc.MaDanhMuc);
            }
        }
        private void LoadTatCaCongViec()
        {
            // Lấy danh sách tất cả công việc của người dùng
            var danhSachCongViec = congViecBLL.GetByTenDangNhap(TenDangNhap);

            // Xóa các công việc cũ trong flp_congViec
            flp_congViec.Controls.Clear();

            // Hiển thị các công việc mới
            foreach (var congViec in danhSachCongViec)
            {
                Uc_congViec ucCongViec = new Uc_congViec
                {
                    TieuDe = congViec.TieuDe,
                    NgayHetHan = congViec.NgayHetHan.HasValue
                    ? congViec.NgayHetHan.Value.ToString("dd/MM/yyyy")
                    : "",
                    HoanThanh = congViec.HoanThanh
                };
                // Đăng ký sự kiện EditClick từ Uc_congViec
                ucCongViec.EditClick += UcCongViec_EditClick;

                // Thêm vào FlowLayoutPanel
                flp_congViec.Controls.Add(ucCongViec);
            }
        }
        private void UcCongViec_EditClick(object sender, EventArgs e)
        {
            // Khi người dùng nhấn sửa, mở Frm_CongViec
            Frm_CongViec frmCongViec = new Frm_CongViec();
            frmCongViec.Show();
        }
        private void AddButtonDanhMuc(string tenDanhMuc, int maDanhMuc)
        {
            Button btnDanhMuc = new Button
            {
                Text = tenDanhMuc,
                Tag = maDanhMuc, // Gắn mã danh mục vào Tag
                AutoSize = true,
                BackColor = System.Drawing.Color.LightBlue,
                Margin = new Padding(5)
            };

            // Gán sự kiện nhấn nút
            btnDanhMuc.Click += BtnDanhMuc_Click;

            // Thêm nút vào flp_danhMuc
            flp_danhMuc.Controls.Add(btnDanhMuc);
        }
        private void AddButtonTatCa()
        {
            Button btnTatCa = new Button
            {
                Text = "Tất cả",
                Tag = null, // Gắn null để biểu thị "Tất cả"
                AutoSize = true,
                BackColor = System.Drawing.Color.LightGreen,
                Margin = new Padding(5)
            };
            btnTatCa.Click += BtnTatCa_Click;
            flp_danhMuc.Controls.Add(btnTatCa);
        }
        private void BtnTatCa_Click(object sender, EventArgs e)
        {
            LoadTatCaCongViec();
        }
        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Lấy mã danh mục từ Tag của Button
                int maDanhMuc = (int)btn.Tag;

                // Lấy danh sách công việc theo mã danh mục
                var danhSachCongViec = congViecBLL.GetByDanhMuc(maDanhMuc);

                // Xóa các công việc cũ trong flp_congViec
                flp_congViec.Controls.Clear();

                // Hiển thị các công việc mới
                foreach (var congViec in danhSachCongViec)
                {
                    Uc_congViec ucCongViec = new Uc_congViec
                    {
                        TieuDe = congViec.TieuDe,
                        NgayHetHan = congViec.NgayHetHan.HasValue
                            ? congViec.NgayHetHan.Value.ToString("dd/MM/yyyy")
                            : "",
                        HoanThanh = congViec.HoanThanh
                    };

                    // Thêm vào FlowLayoutPanel
                    flp_congViec.Controls.Add(ucCongViec);
                }
            }
        }



    }
}
