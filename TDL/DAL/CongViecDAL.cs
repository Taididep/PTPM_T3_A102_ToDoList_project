using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class CongViecDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public CongViecDAL() { }

        // Lấy tất cả công việc
        public IQueryable<dynamic> GetALL()
        {
            return qlcv.CongViecs.Select(k => k);
        }

        // Lấy danh sách công việc theo TenDangNhap
        public List<CongViecDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return qlcv.CongViecs
                       .Where(c => c.TenDangNhap == tenDangNhap)
                       .Select(k => new CongViecDTO
                       {
                           MaCongViec = k.MaCongViec,
                           TieuDe = k.TieuDe,
                           MoTa = k.MoTa,
                           NgayHetHan = k.NgayHetHan,
                           HoanThanh = k.HoanThanh
                       }).ToList();
        }

        // Thêm công việc mới
        public bool Insert(string tenDangNhap, string tieuDe, string moTa, DateTime? ngayHetHan)
        {
            try
            {
                CongViec newCongViec = new CongViec
                {
                    TenDangNhap = tenDangNhap,
                    TieuDe = tieuDe,
                    MoTa = moTa,
                    NgayHetHan = ngayHetHan,
                    HoanThanh = false  // Mặc định là chưa hoàn thành
                };

                qlcv.CongViecs.InsertOnSubmit(newCongViec);
                qlcv.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Xóa công việc
        public bool Delete(int maCongViec)
        {
            try
            {
                var congViecToDelete = qlcv.CongViecs.FirstOrDefault(c => c.MaCongViec == maCongViec);
                if (congViecToDelete != null)
                {
                    qlcv.CongViecs.DeleteOnSubmit(congViecToDelete);
                    qlcv.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy công việc để xóa
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Cập nhật công việc
        public bool Update(int maCongViec, string tieuDe, string moTa, DateTime? ngayHetHan, bool hoanThanh)
        {
            try
            {
                var congViecToUpdate = qlcv.CongViecs.FirstOrDefault(c => c.MaCongViec == maCongViec);
                if (congViecToUpdate != null)
                {
                    congViecToUpdate.TieuDe = tieuDe;
                    congViecToUpdate.MoTa = moTa;
                    congViecToUpdate.NgayHetHan = ngayHetHan;
                    congViecToUpdate.HoanThanh = hoanThanh;

                    qlcv.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy công việc để cập nhật
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
