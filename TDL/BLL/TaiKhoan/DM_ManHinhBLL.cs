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
        public IQueryable<dynamic> GetAll()
        {
            return dalManHinh.GetAll();
        }

        // Lấy thông tin một màn hình
        public DM_ManHinh GetOne(string maManHinh)
        {
            return dalManHinh.GetOne(maManHinh);
        }

        // Thêm màn hình mới
        public bool Insert(DM_ManHinh newScreen)
        {
            if (newScreen == null)
            {
                throw new ArgumentNullException(nameof(newScreen), "Dữ liệu màn hình không hợp lệ.");
            }

            if (string.IsNullOrEmpty(newScreen.MaManHinh) || newScreen.MaManHinh.Length > 50)
            {
                throw new ArgumentException("Mã màn hình không được để trống và phải nhỏ hơn 50 ký tự.");
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
            if (updatedScreen == null || string.IsNullOrEmpty(updatedScreen.MaManHinh))
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
        public bool Delete(string maManHinh)
        {
            if (string.IsNullOrEmpty(maManHinh))
            {
                throw new ArgumentException("Mã màn hình không được để trống.");
            }
            return dalManHinh.Delete(maManHinh);
        }
    }
}
