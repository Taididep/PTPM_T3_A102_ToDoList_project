//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;
//using BLL;
//using BLL.TaiKhoan;
//using DTO;
//using DTO.TaiKhoan;
//using UC.Controls;

//namespace GUI
//{
//    public partial class Frm_QLNguoiDung : Form
//    {
//        private QL_NguoiDungBLL qL_NguoiDungBLL = new QL_NguoiDungBLL();
//        private QL_ThongTinCaNhanBLL qL_ThongTinCaNhanBLL = new QL_ThongTinCaNhanBLL();
//        private List<dynamic> listNguoiDung;

//        public Frm_QLNguoiDung()
//        {
//            InitializeComponent();
//            ConfigureDataGridView();
//            getUserData();
//        }

//        private void ConfigureDataGridView()
//        {
//            dgv_NguoiDung.AutoGenerateColumns = false;
//            dgv_NguoiDung.Columns.Clear();

//            dgv_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                DataPropertyName = "TenDangNhap",
//                HeaderText = "Tên Đăng Nhập",
//                Name = "TenDangNhap",
//                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
//            });

//            dgv_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                DataPropertyName = "HoatDong",
//                HeaderText = "Trạng Thái",
//                Name = "HoatDong",
//                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
//            });
//        }

//        private void getUserData()
//        {
//            try
//            {
//                listNguoiDung = qL_NguoiDungBLL.GetALL().ToList();

//                dgv_NguoiDung.DataSource = listNguoiDung;
//                dgv_NguoiDung.Refresh();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgv_NguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0 && e.RowIndex < dgv_NguoiDung.Rows.Count)
//            {
//                try
//                {
//                    var selectedRow = dgv_NguoiDung.Rows[e.RowIndex];
//                    if (selectedRow.Cells["TenDangNhap"].Value is string tenDangNhap)
//                    {
//                        var thongTin = qL_ThongTinCaNhanBLL.LayThongTinCaNhan(tenDangNhap).FirstOrDefault();

//                        if (thongTin != null)
//                        {
//                            txtTenDangNhap.Text = thongTin.TenDangNhap ?? string.Empty;
//                            txt_Name.Text = thongTin.HoTen ?? string.Empty;
//                            txt_email.Text = thongTin.Email ?? string.Empty;
//                            txt_Sdt.Text = thongTin.SoDienThoai ?? string.Empty;
//                            txtAddress.Text = thongTin.DiaChi ?? string.Empty;
//                            dtp_NgaySinh.Value = thongTin.NgaySinh ?? DateTime.Now;
//                            cbb_GioiTinh.SelectedItem = thongTin.GioiTinh ?? "Nam";
//                        }
//                        else
//                        {
//                            ClearUserForm();
//                            MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Đã xảy ra lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void ClearUserForm()
//        {
//            txtTenDangNhap.Text = string.Empty;
//            txt_Name.Text = string.Empty;
//            txt_email.Text = string.Empty;
//            txt_Sdt.Text = string.Empty;
//            txtAddress.Text = string.Empty;
//            dtp_NgaySinh.Value = DateTime.Now;
//            cbb_GioiTinh.SelectedIndex = -1;
//        }

//        private void btn_sua_Click(object sender, EventArgs e)
//        {
//            if (!ValidateInput())
//            {
//                return;
//            }
//            try
//            {
//                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
//                {
//                    MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                QL_ThongTinCaNhanDTO updatedUser = new QL_ThongTinCaNhanDTO
//                {
//                    TenDangNhap = txtTenDangNhap.Text.Trim(),
//                    HoTen = txt_Name.Text.Trim(),
//                    Email = txt_email.Text.Trim(),
//                    SoDienThoai = txt_Sdt.Text.Trim(),
//                    DiaChi = txtAddress.Text.Trim(),
//                    NgaySinh = dtp_NgaySinh.Value,
//                    GioiTinh = cbb_GioiTinh.SelectedItem?.ToString() ?? "Nam"
//                };

//                int result = qL_ThongTinCaNhanBLL.CapNhatThongTinCaNhan(updatedUser);

//                if (result == 1)
//                {
//                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    getUserData();
//                }
//                else
//                {
//                    MessageBox.Show("Cập nhật thông tin thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private bool ValidateInput()
//        {
//            if (string.IsNullOrWhiteSpace(txt_Name.Text))
//            {
//                MessageBox.Show("Họ tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txt_Name.Focus();
//                return false;
//            }

//            if (!long.TryParse(txt_Sdt.Text, out _) || txt_Sdt.Text.Length < 10 || txt_Sdt.Text.Length > 11)
//            {
//                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập đúng định dạng (10-11 chữ số).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txt_Sdt.Focus();
//                return false;
//            }

//            if (!string.IsNullOrWhiteSpace(txt_email.Text) && !txt_email.Text.Contains("@"))
//            {
//                MessageBox.Show("Email không hợp lệ. Vui lòng nhập đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txt_email.Focus();
//                return false;
//            }

//            if (cbb_GioiTinh.SelectedItem == null)
//            {
//                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                cbb_GioiTinh.Focus();
//                return false;
//            }

//            return true;
//        }



//    }
//}
