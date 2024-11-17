using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC.UserControls
{
    public partial class Uc_congViec : UserControl
    {
        private string tieuDe;
        private string ngayHetHan;
        private bool hoanThanh;

        public event EventHandler EditClick;
        public Uc_congViec()
        {
            InitializeComponent();

            this.btn_edit.Click += Btn_edit_Click;
            this.btn_delete.Click += Btn_delete_Click;
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            // Khi nhấn nút edit, phát ra sự kiện EditClick
            EditClick?.Invoke(this, EventArgs.Empty);
        }

        public bool HoanThanh { get => hoanThanh; set => hoanThanh = value; }
        public string NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public string TieuDe { get => tieuDe; set => tieuDe = value; }

        private void Uc_congViec_Load(object sender, EventArgs e)
        {
            lb_tieuDe.Text = tieuDe;
            lb_ngayHetHan.Text = ngayHetHan;
            check_hoanThanh.Checked = hoanThanh;
        }
    }
}
