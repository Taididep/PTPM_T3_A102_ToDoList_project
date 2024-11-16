using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using UC.Controls;
using System.Data.SqlClient;
using static BLL.QL_NguoiDungBLL;

namespace UC
{
    public partial class Uc_login : UserControl
    {
        private QL_NguoiDungBLL nguoiDungDAL = new QL_NguoiDungBLL();
        public event EventHandler GetChange_login;
        bool _isLogin;
        string _tenDangNhap;
        public Uc_login()
        {
            InitializeComponent();


            //Khai báo event
            this.Btn_login.Click += Btn_login_Click;

        }
        public bool IsLogin { get => _isLogin; set => _isLogin = value; }
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text.Trim()) || string.IsNullOrEmpty(txt_password.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xử lý đăng nhập
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            IsLogin = false;
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            var result = nguoiDungDAL.Check_User(username, password);

            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lb_username.Text + " hoặc " + lb_password.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == LoginResult.Success)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsLogin = true;
                _tenDangNhap = username;

                // Gửi sự kiện thông báo đăng nhập thành công
                GetChange_login?.Invoke(this, EventArgs.Empty);
            }
        }



    }
}
