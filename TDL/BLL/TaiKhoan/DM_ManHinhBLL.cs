using DTO;
using DAL;
using System.Linq;
using System;

namespace BLL
{
    public class DM_ManHinhBLL
    {
        DM_ManHinhDAL dalManHinh = new DM_ManHinhDAL();

        public DM_ManHinhBLL() { }

        // Lấy danh sách tất cả màn hình
        public IQueryable<dynamic> GetALL()
        {
            return dalManHinh.GetALL();
        }

        // Lấy thông tin một màn hình
        public DM_ManHinh GetOne(int screenId)
        {
            if (screenId <= 0)
            {
                throw new ArgumentException("Mã màn hình không hợp lệ.");
            }
            return dalManHinh.GetOne(screenId);
        }

        // Thêm màn hình mới
        public bool Insert(DM_ManHinh newScreen)
        {
            if (newScreen == null)
            {
                throw new ArgumentNullException(nameof(newScreen), "Dữ liệu màn hình không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newScreen.TenManHinh) || newScreen.TenManHinh.Length > 255)
            {
                throw new ArgumentException("Tên màn hình không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalManHinh.Insert(newScreen);
        }

        // Cập nhật thông tin màn hình
        public bool Update(DM_ManHinh updatedScreen)
        {
            if (updatedScreen == null || updatedScreen.ScreenId <= 0)
            {
                throw new ArgumentException("Mã màn hình không hợp lệ.");
            }

            if (string.IsNullOrEmpty(updatedScreen.TenManHinh) || updatedScreen.TenManHinh.Length > 255)
            {
                throw new ArgumentException("Tên màn hình không được để trống và phải nhỏ hơn 255 ký tự.");
            }

            return dalManHinh.Update(updatedScreen);
        }

        // Xóa màn hình
        public bool Delete(int screenId)
        {
            if (screenId <= 0)
            {
                throw new ArgumentException("Mã màn hình không hợp lệ.");
            }
            return dalManHinh.Delete(screenId);
        }
    }
}
