using DTO;
using DAL;
using System.Linq;
using System;

namespace BLL
{
    public class QL_NguoiDungNhomNguoiDungBLL
    {
        QL_NguoiDungNhomNguoiDungDAL dalNguoiDungNhom = new QL_NguoiDungNhomNguoiDungDAL();

        public QL_NguoiDungNhomNguoiDungBLL() { }

        // Lấy danh sách tất cả người dùng thuộc nhóm người dùng
        public IQueryable<dynamic> GetAll()
        {
            return dalNguoiDungNhom.GetAll();
        }

        // Lấy thông tin một người dùng thuộc nhóm người dùng
        public QL_NguoiDungNhomNguoiDung GetOne(string username, string groupId)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("Tên đăng nhập và mã nhóm người dùng không được để trống.");
            }

            return dalNguoiDungNhom.GetOne(username, groupId);
        }

        // Thêm mới quan hệ người dùng - nhóm người dùng
        public bool Insert(QL_NguoiDungNhomNguoiDung newUserGroup)
        {
            if (newUserGroup == null)
            {
                throw new ArgumentNullException(nameof(newUserGroup), "Dữ liệu nhóm người dùng không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newUserGroup.TenDangNhap) || string.IsNullOrEmpty(newUserGroup.MaNhomNguoiDung))
            {
                throw new ArgumentException("Tên đăng nhập và mã nhóm người dùng phải hợp lệ.");
            }

            return dalNguoiDungNhom.Insert(newUserGroup);
        }

        // Cập nhật thông tin quan hệ người dùng - nhóm người dùng
        public bool Update(QL_NguoiDungNhomNguoiDung updatedUserGroup)
        {
            if (updatedUserGroup == null
                || string.IsNullOrEmpty(updatedUserGroup.TenDangNhap)
                || string.IsNullOrEmpty(updatedUserGroup.MaNhomNguoiDung))
            {
                throw new ArgumentException("Dữ liệu nhóm người dùng không hợp lệ.");
            }

            return dalNguoiDungNhom.Update(updatedUserGroup);
        }

        // Xóa quan hệ người dùng - nhóm người dùng
        public bool Delete(string username, string groupId)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("Tên đăng nhập và mã nhóm người dùng không được để trống.");
            }

            return dalNguoiDungNhom.Delete(username, groupId);
        }
    }
}
