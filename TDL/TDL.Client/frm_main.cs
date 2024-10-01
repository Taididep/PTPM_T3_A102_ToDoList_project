using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TDL.Client.Module_DNTableAdapters;

namespace TDL.Client
{
    public partial class frm_main : Form
    {
        string _tenDangNhap;
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }

        public frm_main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true;
            this.FormClosed += frm_main_FormClosed;
            this.Load += Frm_main_Load;
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            List<string> NhomND = new List<string>();
            QL_NguoiDungNhomNguoiDungGetMaNhomNguoiDungTableAdapter ketqua = dt.GetData(_tenDangNhap);



        }

        private void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }

        private void nguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_nguoidung frm = new frm_nguoidung();
            frm.MdiParent = this;
            frm.Show();
        }

        private void themNguoiDungVaoNhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_themNguoiDungVaoNhom frm = new frm_themNguoiDungVaoNhom();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
