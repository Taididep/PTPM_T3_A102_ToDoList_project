using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC
{
    public partial class Uc_login: UserControl
    {
        public Uc_login()
        {
            InitializeComponent();




            //Khai báo event
            this.Btn_login.Click += Btn_login_Click;
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            
        }
    }
}
