using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using UC.UserControls;

namespace GUI
{
    public partial class Frm_Home : Form
    {
        private string _tenDangNhap;
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }
        public Frm_Home()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        static Frm_Home _obj;
        public static Frm_Home Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Frm_Home();
                }
                return _obj;
            }
        }
        
        public void AddControlls(Form f)
        {
            panel1.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            AddControlls(new Frm_QLNguoiDung());
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
                Frm_login frm = new Frm_login();
                frm.ShowDialog();
            }
        }

        private void Frm_Home_Load(object sender, EventArgs e)
        {

        }

        private void btn_customer_Click_1(object sender, EventArgs e)
        {
            AddControlls(new Frm_QLNguoiDung());
        }
    }
}
