using DTO;
using DAL;
using System.Linq;
using System;

namespace BLL
{
    public class QL_NguoiDungNhomNguoiDungBLL
    {
        QL_NguoiDungNhomNguoiDungDAL dalNhomNguoiDung = new QL_NguoiDungNhomNguoiDungDAL();

        public QL_NguoiDungNhomNguoiDungBLL() { }

        // Lấy danh sách tất cả nhóm người dùng
        public IQueryable<dynamic> GetALL()
        {
            return dalNhomNguoiDung.GetALL();
        }

        // Lấy thông tin một nhóm người dùng
        public QL_NguoiDungNhomNguoiDung GetOne(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Tên đăng nhập không hợp lệ.");
            }
            return dalNhomNguoiDung.GetOne(username);
        }

        // Thêm nhóm người dùng mới
        public bool Insert(QL_NguoiDungNhomNguoiDung newUserGroup)
        {
            if (newUserGroup == null)
            {
                throw new ArgumentNullException(nameof(newUserGroup), "Dữ liệu nhóm người dùng không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newUserGroup.TenDangNhap) || newUserGroup.NhomId <= 0)
            {
                throw new ArgumentException("Tên đăng nhập và mã nhóm người dùng phải hợp lệ.");
            }

            return dalNhomNguoiDung.Insert(newUserGroup);
        }

        // Cập nhật nhóm người dùng
        public bool Update(QL_NguoiDungNhomNguoiDung updatedUserGroup)
        {
            if (updatedUserGroup == null || updatedUserGroup.NhomId <= 0 || string.IsNullOrEmpty(updatedUserGroup.TenDangNhap))
            {
                throw new ArgumentException("Dữ liệu nhóm người dùng không hợp lệ.");
            }

            return dalNhomNguoiDung.Update(updatedUserGroup);
        }

        // Xóa nhóm người dùng
        public bool Delete(string username, int groupId)
        {
            if (string.IsNullOrEmpty(username) || groupId <= 0)
            {
                throw new ArgumentException("Tên đăng nhập và mã nhóm người dùng không hợp lệ.");
            }
            return dalNhomNguoiDung.Delete(username, groupId);
        }
    }
}
