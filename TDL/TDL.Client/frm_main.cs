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
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            await Task.Delay(200);
            Program.loginForm.Show();
        }
    }
}
