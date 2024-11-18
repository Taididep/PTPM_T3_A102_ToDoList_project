using DTO;
using DAL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class CongViecBLL
    {
        CongViecDAL dalCongViec = new CongViecDAL();

        public CongViecBLL() { }

        // Lấy tất cả công việc
        // Lấy danh sách tất cả công việc
        public List<CongViecDTO> GetAll()
        {
            return dalCongViec.GetAll();
        }

        // Lấy danh sách công việc theo TenDangNhap
        public List<CongViecDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return string.IsNullOrEmpty(tenDangNhap) ? new List<CongViecDTO>() : dalCongViec.GetByTenDangNhap(tenDangNhap);
        }

        // Lấy danh sách công việc theo danh mục
        public List<CongViecDTO> GetByDanhMuc(int maDanhMuc)
        {
            return maDanhMuc <= 0 ? new List<CongViecDTO>() : dalCongViec.GetByDanhMuc(maDanhMuc);
        }

        // Thêm công việc mới
        public bool Insert(CongViecDTO congViec)
        {
            if (congViec == null || string.IsNullOrEmpty(congViec.TieuDe) || string.IsNullOrEmpty(congViec.TenDangNhap))
                return false;

            return dalCongViec.Insert(congViec);
        }

        // Xóa công việc
        public bool Delete(int maCongViec)
        {
            return maCongViec > 0 && dalCongViec.Delete(maCongViec);
        }

        // Cập nhật công việc
        public bool Update(CongViecDTO congViec)
        {
            if (congViec == null || congViec.MaCongViec <= 0 || string.IsNullOrEmpty(congViec.TieuDe))
                return false;

            return dalCongViec.Update(congViec);
        }
    }
}
