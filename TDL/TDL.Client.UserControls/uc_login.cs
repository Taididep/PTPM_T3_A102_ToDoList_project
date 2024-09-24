using System;
using System.Data.SqlTypes;
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

        public uc_login()
        {
            InitializeComponent();
        }

        public string Cnn
        {
            get { return _cnn; }
            set { _cnn = value; }
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }
            SQLClass sqldt = new SQLClass();
            int kq = sqlMangement.Check_Config(Cnn, sqldt); //hàm Check_Config() thuộc UserManagement

            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                //ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                //ProcessConfig();
            }
        }


        public void ProcessLogin()
        {
            LoginResult result;
            result = userManagement.Check_User(txt_username.Text, txt_password.Text, Cnn); //

            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lb_username.Text + " Hoặc " + lb_password.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            MessageBox.Show("Dang nhap ok");
        }


    }
}
