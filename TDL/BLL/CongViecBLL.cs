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
        public IQueryable<dynamic> GetALL()
        {
            return dalCongViec.GetALL();
        }

        // Lấy công việc theo TenDangNhap
        public List<CongViecDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return dalCongViec.GetByTenDangNhap(tenDangNhap);
        }

        public List<CongViecDTO> GetByDanhMuc(int maDanhMuc)
        {
            return dalCongViec.GetByDanhMuc(maDanhMuc);
        }


        // Thêm công việc mới
        public bool Insert(string tenDangNhap, string tieuDe, string moTa, DateTime? ngayHetHan)
        {
            return dalCongViec.Insert(tenDangNhap, tieuDe, moTa, ngayHetHan);
        }

        // Xóa công việc
        public bool Delete(int maCongViec)
        {
            return dalCongViec.Delete(maCongViec);
        }

        // Cập nhật công việc
        public bool Update(int maCongViec, string tieuDe, string moTa, DateTime? ngayHetHan, bool hoanThanh)
        {
            return dalCongViec.Update(maCongViec, tieuDe, moTa, ngayHetHan, hoanThanh);
        }
    }
}
