using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace UC
{
    public partial class Uc_login : UserControl
    {
        private bool _isLogin;
        private string _tenDangNhap;

        public event EventHandler GetChange_login;

        public Uc_login()
        {
            InitializeComponent();
            // Khai báo sự kiện
            this.Btn_login.Click += Btn_login_Click;
        }

        public bool IsLogin { get => _isLogin; set => _isLogin = value; }
        public string TenDangNhap { get => _tenDangNhap; set => _tenDangNhap = value; }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_username.Text.Trim()) || string.IsNullOrEmpty(txt_password.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xử lý đăng nhập
            ProcessLogin();
        }

        private async void ProcessLogin()
        {
            IsLogin = false;
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            var loginRequest = new { TenDangNhap = username, MatKhau = password };

            // Gọi API để thực hiện đăng nhập
            var loginResult = await CallLoginApi(loginRequest);

            if (loginResult == "Invalid")
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (loginResult == "Disabled")
            {
                MessageBox.Show("Tài khoản bị khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (loginResult == "Success")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsLogin = true;
                _tenDangNhap = username;

                // Gửi sự kiện thông báo đăng nhập thành công
                GetChange_login?.Invoke(this, EventArgs.Empty);
            }
        }

        private async Task<string> CallLoginApi(object loginRequest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST tới API
                var response = await client.PostAsync("api/NguoiDung/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    var resultObject = JsonConvert.DeserializeObject<dynamic>(resultJson);
                    return resultObject.message; // Trả về giá trị "message"
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
