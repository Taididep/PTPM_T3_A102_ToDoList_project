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
        public IQueryable<dynamic> GetAll()
        {
            return dalNhomNguoiDung.GetAll();
        }

        // Lấy thông tin một nhóm người dùng theo mã nhóm
        public QL_NhomNguoiDung GetOne(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                return null;
            }
            return dalNhomNguoiDung.GetOne(groupId);
        }

        // Thêm nhóm người dùng mới
        public bool Insert(QL_NhomNguoiDung newGroup)
        {
            if (newGroup == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(newGroup.TenNhom))
            {
                return false;
            }

            return dalNhomNguoiDung.Insert(newGroup);
        }

        // Cập nhật nhóm người dùng
        public bool Update(QL_NhomNguoiDung updatedGroup)
        {
            if (updatedGroup == null || string.IsNullOrEmpty(updatedGroup.MaNhom))
            {
                return false;
            }

            if (string.IsNullOrEmpty(updatedGroup.TenNhom))
            {
                return false;
            }

            return dalNhomNguoiDung.Update(updatedGroup);
        }

        // Xóa nhóm người dùng
        public bool Delete(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                return false;
            }
            return dalNhomNguoiDung.Delete(groupId);
        }
    }
}