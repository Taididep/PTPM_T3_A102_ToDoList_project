using System;
using System.Web;

namespace FE
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Xóa Session của người dùng
            Session.Clear();  // Xóa tất cả dữ liệu trong Session
            Session.Abandon();  // Hủy session hiện tại

            // Chuyển hướng về trang đăng nhập
            Response.Redirect("Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
