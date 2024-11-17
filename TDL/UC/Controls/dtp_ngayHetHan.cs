
using System.Windows.Forms;

namespace UC.Controls
{
    public class dtp_ngayHetHan : DateTimePicker
    {
        public dtp_ngayHetHan() 
        {
            // Thiết lập định dạng tùy chỉnh
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dddd dd/MM/yyyy"; // Định dạng "Thứ dd/MM/yyyy"
        }
    }
}
