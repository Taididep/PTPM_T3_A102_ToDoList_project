using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace FE
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                await HandleLoginAsync(); // Gọi trực tiếp bằng await
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Lỗi: {ex.Message}";
            }
        }

        protected async Task HandleLoginAsync()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
                return;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var url = "https://localhost:44341/api/NguoiDung/Login";
                    var content = new StringContent(
                        $"{{\"TenDangNhap\":\"{username}\",\"MatKhau\":\"{password}\"}}",
                        Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        if (result.Contains("\"message\":\"Success\""))
                        {
                            Session["TenDangNhap"] = username; // Lưu TenDangNhap vào Session
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Đăng nhập thành công!";
                            Response.Redirect("/Home/Index.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            lblMessage.Text = "Sai tên đăng nhập hoặc mật khẩu.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Có lỗi xảy ra, vui lòng thử lại.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Lỗi: {ex.Message}";
            }
        }

    }
}
