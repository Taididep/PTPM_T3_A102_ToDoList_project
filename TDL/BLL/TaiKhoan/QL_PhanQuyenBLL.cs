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
        public IQueryable<dynamic> GetALL()
        {
            return dalPhanQuyen.GetALL();
        }

        // Lấy thông tin một quyền
        public QL_PhanQuyen GetOne(int permissionId)
        {
            if (permissionId <= 0)
            {
                throw new ArgumentException("Mã quyền không hợp lệ.");
            }
            return dalPhanQuyen.GetOne(permissionId);
        }

        // Thêm quyền mới
        public bool Insert(QL_PhanQuyen newPermission)
        {
            if (newPermission == null)
            {
                throw new ArgumentNullException(nameof(newPermission), "Dữ liệu quyền không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newPermission.TenQuyen) || newPermission.TenQuyen.Length > 255)
            {
                throw new ArgumentException("Tên quyền không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalPhanQuyen.Insert(newPermission);
        }

        // Cập nhật quyền
        public bool Update(QL_PhanQuyen updatedPermission)
        {
            if (updatedPermission == null || updatedPermission.PermissionId <= 0)
            {
                throw new ArgumentException("Mã quyền không hợp lệ.");
            }

            if (string.IsNullOrEmpty(updatedPermission.TenQuyen) || updatedPermission.TenQuyen.Length > 255)
            {
                throw new ArgumentException("Tên quyền không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalPhanQuyen.Update(updatedPermission);
        }

        // Xóa quyền
        public bool Delete(int permissionId)
        {
            if (permissionId <= 0)
            {
                throw new ArgumentException("Mã quyền không hợp lệ.");
            }
            return dalPhanQuyen.Delete(permissionId);
        }
    }
}
