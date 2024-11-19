<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FE.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Đăng Nhập</h2>
            <label for="txtUsername">Tên đăng nhập:</label>
            <input type="text" id="txtUsername" name="txtUsername" />
            <br />
            <label for="txtPassword">Mật khẩu:</label>
            <input type="password" id="txtPassword" name="txtPassword" />
            <br />
            <button type="button" id="btnLogin">Đăng nhập</button>

            <div id="message" style="color: red; margin-top: 10px;"></div>
        </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnLogin').click(function () {
                var username = $('#txtUsername').val();
                var password = $('#txtPassword').val();

                if (username === "" || password === "") {
                    $('#message').text("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                    return;
                }

                // Gửi yêu cầu POST đến API
                $.ajax({
                    url: 'https://localhost:44341/api/NguoiDung/Login', // URL API login
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify({
                        TenDangNhap: username,
                        MatKhau: password
                    }),
                    success: function (data) {
                        if (data.message === "Success") {
                            $('#message').css("color", "green").text("Đăng nhập thành công!");
                            // Điều hướng tới trang khác hoặc lưu trữ thông tin người dùng
                            window.location.href = "/Home.aspx"; // Ví dụ: Chuyển sang trang chính
                        } else if (data.message === "Invalid") {
                            $('#message').text("Sai tên đăng nhập hoặc mật khẩu.");
                        } else if (data.message === "Disabled") {
                            $('#message').text("Tài khoản bị khóa.");
                        }
                    },
                    error: function () {
                        $('#message').text("Có lỗi xảy ra, vui lòng thử lại.");
                    }
                });
            });
        });
    </script>
</body>
</html>
