using System;
using System.Windows.Forms;
using TDL.Client.Module_DNTableAdapters;

namespace TDL.Client
{
    public partial class frm_themNguoiDungVaoNhom : Form
    {
        public frm_themNguoiDungVaoNhom()
        {
            InitializeComponent();
            qL_NhomNguoiDungComboBox.SelectedIndexChanged += qL_NhomNguoiDungComboBox_SelectedIndexChanged;
            this.btn_them.Click += Btn_them_Click;
            this.btn_xoa.Click += Btn_xoa_Click; 
            
            
        }

        private void Btn_xoa_Click(object sender, EventArgs e)
        {
            QL_NguoiDungNhomNguoiDungTableAdapter dt_NDNND = new QL_NguoiDungNhomNguoiDungTableAdapter();

            string tenDN = qL_NguoiDungNhomNguoiDung_DKDataGridView.CurrentRow.Cells[0].Value.ToString();
            string maNhom = qL_NhomNguoiDungComboBox.SelectedValue.ToString();


            dt_NDNND.Xoa(tenDN, maNhom);

            MessageBox.Show("Thanh cong");

            LoadDK();

        }

        private void Btn_them_Click(object sender, EventArgs e)
        {
            QL_NguoiDungNhomNguoiDungTableAdapter dt_NDNND = new QL_NguoiDungNhomNguoiDungTableAdapter();

            string tenDN = qL_NguoiDungDataGridView.CurrentRow.Cells[0].Value.ToString();
            string maNhom = qL_NhomNguoiDungComboBox.SelectedValue.ToString();

            int? KQ = dt_NDNND.KTKC(tenDN, maNhom);

            if(KQ.Value > 0)
            {
                MessageBox.Show("Trung khoa chinh");
                return;
            }

            dt_NDNND.Insert(tenDN, maNhom, string.Empty);

            MessageBox.Show("Thanh cong");

            LoadDK();
        }


        public void LoadDK()
        {
            string maNhom = qL_NhomNguoiDungComboBox.SelectedValue.ToString();

            try
            {
                this.qL_NguoiDungNhomNguoiDung_DKTableAdapter.Fill(this.module_DN.QL_NguoiDungNhomNguoiDung_DK, maNhom);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void qL_NhomNguoiDungComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDK();
        }

        private void qL_NguoiDungBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qL_NguoiDungBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.module_DN);

        }

        private void frm_themnguoidungvaonhom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'module_DN.QL_NguoiDungNhomNguoiDung' table. You can move, or remove it, as needed.
            this.qL_NguoiDungNhomNguoiDungTableAdapter.Fill(this.module_DN.QL_NguoiDungNhomNguoiDung);
            // TODO: This line of code loads data into the 'module_DN.QL_NhomNguoiDung' table. You can move, or remove it, as needed.
            this.qL_NhomNguoiDungTableAdapter.Fill(this.module_DN.QL_NhomNguoiDung);
            // TODO: This line of code loads data into the 'module_DN.QL_NguoiDung' table. You can move, or remove it, as needed.
            this.qL_NguoiDungTableAdapter.Fill(this.module_DN.QL_NguoiDung);

        }

        private void qL_NhomNguoiDungComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
