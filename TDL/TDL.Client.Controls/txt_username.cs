using System.Windows.Forms;

namespace TDL.Client.Controls
{
    public class txt_username : TextBox
    {
        public txt_username()
        {
            this.KeyPress += txt_userName_KeyPress;
        }

        private void txt_userName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Kiểm tra nếu người dùng nhấn phím Enter
            {
                e.Handled = true; // Ngăn chặn beep mặc định
            }
        }
    }
}
