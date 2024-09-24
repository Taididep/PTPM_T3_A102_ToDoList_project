using System.Windows.Forms;

namespace TDL.Client.Controls
{
    public class txt_password : TextBox
    {
        public txt_password()
        {
            this.KeyPress += txt_password_KeyPress;
            this.UseSystemPasswordChar = true;
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Kiểm tra nếu người dùng nhấn phím Enter
            {
                e.Handled = true; // Ngăn chặn beep mặc định
            }
        }
    }

}
