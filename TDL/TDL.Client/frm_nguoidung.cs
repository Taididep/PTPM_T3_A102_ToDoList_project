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
    public partial class frm_nguoidung : Form
    {
        public frm_nguoidung()
        {
            InitializeComponent();
        }

        private void qL_NguoiDungBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qL_NguoiDungBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.module_DN);

        }

        private void frm_NguoiDung_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'module_DN.QL_NguoiDung' table. You can move, or remove it, as needed.
            this.qL_NguoiDungTableAdapter.Fill(this.module_DN.QL_NguoiDung);

        }
    }
}
