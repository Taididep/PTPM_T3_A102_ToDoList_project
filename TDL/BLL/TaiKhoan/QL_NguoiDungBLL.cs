using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class QL_NguoiDungBLL
    {
        QL_NguoiDungDAL dalNguoiDung = new QL_NguoiDungDAL();

        public QL_NguoiDungBLL() { }

        // Lấy danh sách tất cả người dùng
        public IQueryable<dynamic> GetALL()
        {
            return dalNguoiDung.GetALL();
        }

        // Lấy thông tin một người dùng
        public QL_NguoiDung GetOne(string username)
        {
            return dalNguoiDung.GetOne(username);
        }


        // Thêm người dùng mới
        public bool Insert(QL_NguoiDung newUser)
        {
            if (string.IsNullOrEmpty(newUser.TenDangNhap) || string.IsNullOrEmpty(newUser.MatKhau))
            {
                return false; // Kiểm tra dữ liệu đầu vào
            }
            return dalNguoiDung.Insert(newUser);
        }

        // Cập nhật thông tin người dùng
        public bool Update(QL_NguoiDung updatedUser)
        {
            if (string.IsNullOrEmpty(updatedUser.TenDangNhap))
            {
                return false; // Kiểm tra dữ liệu đầu vào
            }
            return dalNguoiDung.Update(updatedUser);
        }

        // Xóa người dùng
        public bool Delete(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false; // Kiểm tra dữ liệu đầu vào
            }
            return dalNguoiDung.Delete(username);
        }

        public enum LoginResult
        {
            /// <summary>
            /// Wrong username or password
            /// </summary>
            Invalid,
            /// <summary>
            /// User had been disabled
            /// </summary>
            Disabled,
            /// <summary>
            /// Loging success
            /// </summary>
            Success
        }
        public LoginResult Check_User(string pUser, string pPass)
        {
            // Truy vấn từ cơ sở dữ liệu hoặc nguồn dữ liệu khác
            var user = dalNguoiDung.GetOne(pUser);

            if (user == null || user.MatKhau != pPass)
            {
                return LoginResult.Invalid; // Sai tên đăng nhập hoặc mật khẩu
            }

            if (user.HoatDong == false)
            {
                return LoginResult.Disabled; // Tài khoản bị khóa
            }

            return LoginResult.Success; // Đăng nhập thành công
        }
    }
}
