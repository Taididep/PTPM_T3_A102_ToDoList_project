using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC.Controls
{
    public class Txt_password : TextBox
    {
        public Txt_password()
        {
            this.KeyPress += Txt_password_KeyPress;
            this.UseSystemPasswordChar = true;
        }

        private void Txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Kiểm tra nếu người dùng nhấn phím Enter
            {
                e.Handled = true; // Ngăn chặn beep mặc định
            }
        }
    }
}
