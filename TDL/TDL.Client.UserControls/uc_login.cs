using System;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TDL.Repositories;
using TDL.Service;
using static TDL.Service.UserManagement;


namespace TDL.Client.UserControls
{
    public partial class uc_login : UserControl
    {
        string _cnn;
        SQLManagement sqlMangement = new SQLManagement();
        UserManagement userManagement = new UserManagement();
        string _tenDangNhap;


        public event EventHandler GetChange_login;
        bool _isLogin;
        
        public uc_login()
        {
            InitializeComponent();
        }

        public string Cnn
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        public bool IsLogin { get => _isLogin; set => _isLogin = value; }
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu");
                return;
            }
            int kq = sqlMangement.Check_Config(Cnn);
            if (kq == 0)
            {
                ProcessLogin();     // kiểm tra đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");    // Xử lý cấu hình
                //ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");    // Xử lý cấu hình
                //ProcessConfig();
            }
        }


        public void ProcessLogin()
        {
            IsLogin = false;
            LoginResult result;
            result = userManagement.Check_User(txt_username.Text, txt_password.Text, Cnn); //

            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lb_username.Text + " Hoặc " + lb_password.Text);
                return;
            }
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            IsLogin = true;
            _tenDangNhap = txt_username.Text;
            GetChange_login.Invoke(this, EventArgs.Empty);

        }
    }
}
