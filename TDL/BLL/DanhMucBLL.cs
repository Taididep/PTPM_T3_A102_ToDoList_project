using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class DanhMucBLL
    {
        DanhMucDAL dalDanhMuc = new DanhMucDAL();

        public DanhMucBLL() { }

        // Lấy tất cả danh mục
        public IQueryable<dynamic> GetALL()
        {
            return dalDanhMuc.GetALL();
        }

        // Lấy danh sách danh mục theo TenDangNhap
        public List<DanhMucDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return dalDanhMuc.GetByTenDangNhap(tenDangNhap);
        }

        // Thêm danh mục mới
        public bool Insert(string tenDangNhap, string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
            {
                throw new ArgumentException("Tên danh mục không được để trống!");
            }

            return dalDanhMuc.Insert(tenDangNhap, tenDanhMuc);
        }

        // Xóa danh mục
        public bool Delete(int maDanhMuc)
        {
            if (maDanhMuc <= 0)
            {
                throw new ArgumentException("Mã danh mục không hợp lệ!");
            }

            return dalDanhMuc.Delete(maDanhMuc);
        }

        // Cập nhật danh mục
        public bool Update(int maDanhMuc, string tenDanhMuc)
        {
            if (maDanhMuc <= 0)
            {
                throw new ArgumentException("Mã danh mục không hợp lệ!");
            }

            if (string.IsNullOrWhiteSpace(tenDanhMuc))
            {
                throw new ArgumentException("Tên danh mục không được để trống!");
            }

            return dalDanhMuc.Update(maDanhMuc, tenDanhMuc);
        }
    }
}
