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
                return false;
            }

            if (string.IsNullOrEmpty(newScreen.MaManHinh))
            {
                return false;
            }

            if (string.IsNullOrEmpty(newScreen.TenManHinh))
            {
                return false;
            }

            return dalManHinh.Insert(newScreen);
        }

        // Cập nhật thông tin màn hình
        public bool Update(DM_ManHinh updatedScreen)
        {
            if (updatedScreen == null || string.IsNullOrEmpty(updatedScreen.MaManHinh))
            {
                return false;
            }

            if (string.IsNullOrEmpty(updatedScreen.TenManHinh))
            {
                return false;
            }

            return dalManHinh.Update(updatedScreen);
        }

        // Xóa màn hình
        public bool Delete(string maManHinh)
        {
            if (string.IsNullOrEmpty(maManHinh))
            {
                return false;
            }
            return dalManHinh.Delete(maManHinh);
        }
    }
}
