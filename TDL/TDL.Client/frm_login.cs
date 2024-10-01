using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDL.Client
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            this.uc_login.Load += Uc_login_Load;

            uc_login.GetChange_login += Uc_login_GetChange_login;
        }

        private void Uc_login_GetChange_login(object sender, EventArgs e)
        {
            if(uc_login.IsLogin)
            {
                //MessageBox.Show("Đăng nhập thành công");

                if (Program.mainForm == null || Program.mainForm.IsDisposed)
                {
                    Program.mainForm = new frm_main();
                }
                this.Visible = false;
                Program.mainForm.TenDangNhap = uc_login.TenDangNhap;
                Program.mainForm.Show();
            }
        }

        private void Uc_login_Load(object sender, EventArgs e)
        {
            uc_login.Cnn = TDL.Client.Properties.Settings.Default.Cnn;
        }
    }
}
