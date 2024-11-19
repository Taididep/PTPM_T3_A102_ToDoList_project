using DTO;
using DAL;
using System.Linq;
using System;

namespace BLL
{
    public class QL_PhanQuyenBLL
    {
        QL_PhanQuyenDAL dalPhanQuyen = new QL_PhanQuyenDAL();

        public QL_PhanQuyenBLL() { }

        // Lấy danh sách tất cả quyền
        public IQueryable<dynamic> GetAll()
        {
            return dalPhanQuyen.GetAll();
        }

        // Lấy thông tin một quyền theo MaNhomNguoiDung và MaManHinh
        public QL_PhanQuyen GetOne(string maNhomNguoiDung, string maManHinh)
        {
            if (string.IsNullOrEmpty(maNhomNguoiDung) || string.IsNullOrEmpty(maManHinh))
            {
                throw new ArgumentException("Mã nhóm người dùng hoặc mã màn hình không hợp lệ.");
            }
            return dalPhanQuyen.GetOne(maNhomNguoiDung, maManHinh);
        }

        // Thêm phân quyền mới
        public bool Insert(QL_PhanQuyen newPermission)
        {
            if (newPermission == null)
            {
                throw new ArgumentNullException(nameof(newPermission), "Dữ liệu phân quyền không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newPermission.MaNhomNguoiDung) || string.IsNullOrEmpty(newPermission.MaManHinh))
            {
                throw new ArgumentException("Mã nhóm người dùng và mã màn hình không được để trống.");
            }

            return dalPhanQuyen.Insert(newPermission);
        }

        // Cập nhật phân quyền
        public bool Update(QL_PhanQuyen updatedPermission)
        {
            if (updatedPermission == null || string.IsNullOrEmpty(updatedPermission.MaNhomNguoiDung) || string.IsNullOrEmpty(updatedPermission.MaManHinh))
            {
                throw new ArgumentException("Dữ liệu phân quyền không hợp lệ.");
            }

            return dalPhanQuyen.Update(updatedPermission);
        }

        // Xóa phân quyền
        public bool Delete(string maNhomNguoiDung, string maManHinh)
        {
            if (string.IsNullOrEmpty(maNhomNguoiDung) || string.IsNullOrEmpty(maManHinh))
            {
                throw new ArgumentException("Mã nhóm người dùng và mã màn hình không hợp lệ.");
            }
            return dalPhanQuyen.Delete(maNhomNguoiDung, maManHinh);
        }
    }
}
