using DTO;
using DAL;
using System.Linq;
using System;

namespace BLL
{
    public class QL_NhomNguoiDungBLL
    {
        QL_NhomNguoiDungDAL dalNhomNguoiDung = new QL_NhomNguoiDungDAL();

        public QL_NhomNguoiDungBLL() { }

        // Lấy danh sách tất cả nhóm người dùng
        public IQueryable<dynamic> GetALL()
        {
            return dalNhomNguoiDung.GetALL();
        }

        // Lấy thông tin một nhóm người dùng
        public QL_NhomNguoiDung GetOne(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("Mã nhóm người dùng không hợp lệ.");
            }
            return dalNhomNguoiDung.GetOne(groupId);
        }

        // Thêm nhóm người dùng mới
        public bool Insert(QL_NhomNguoiDung newGroup)
        {
            if (newGroup == null)
            {
                throw new ArgumentNullException(nameof(newGroup), "Dữ liệu nhóm người dùng không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newGroup.TenNhom) || newGroup.TenNhom.Length > 255)
            {
                throw new ArgumentException("Tên nhóm người dùng không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalNhomNguoiDung.Insert(newGroup);
        }

        // Cập nhật nhóm người dùng
        public bool Update(QL_NhomNguoiDung updatedGroup)
        {
            if (updatedGroup == null || updatedGroup.GroupId <= 0)
            {
                throw new ArgumentException("Mã nhóm người dùng không hợp lệ.");
            }

            if (string.IsNullOrEmpty(updatedGroup.TenNhom) || updatedGroup.TenNhom.Length > 255)
            {
                throw new ArgumentException("Tên nhóm người dùng không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalNhomNguoiDung.Update(updatedGroup);
        }

        // Xóa nhóm người dùng
        public bool Delete(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("Mã nhóm người dùng không hợp lệ.");
            }
            return dalNhomNguoiDung.Delete(groupId);
        }
    }
}
