using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class CongViecDAL
    {
        private readonly QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public CongViecDAL() { }

        // Lấy danh sách tất cả công việc
        public List<CongViecDTO> GetAll()
        {
            return qlcv.CongViecs.Select(cv => new CongViecDTO
            {
                MaCongViec = cv.MaCongViec,
                TenDangNhap = cv.TenDangNhap,
                TieuDe = cv.TieuDe,
                MoTa = cv.MoTa,
                NgayHetHan = cv.NgayHetHan,
                HoanThanh = cv.HoanThanh
            }).ToList();
        }

        // Lấy danh sách công việc theo TenDangNhap
        public List<CongViecDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return qlcv.CongViecs
                .Where(cv => cv.TenDangNhap == tenDangNhap)
                .Select(cv => new CongViecDTO
                {
                    MaCongViec = cv.MaCongViec,
                    TenDangNhap = cv.TenDangNhap,
                    TieuDe = cv.TieuDe,
                    MoTa = cv.MoTa,
                    NgayHetHan = cv.NgayHetHan,
                    HoanThanh = cv.HoanThanh
                }).ToList();
        }

        // Lấy danh sách công việc theo danh mục
        public List<CongViecDTO> GetByTenDangNhapAndDanhMuc(int maDanhMuc, string tenDangNhap)
        {
            return qlcv.CongViecDanhMucs
                .Where(cdm => cdm.MaDanhMuc == maDanhMuc && cdm.CongViec.TenDangNhap == tenDangNhap)
                .Select(cdm => cdm.CongViec)
                .Select(cv => new CongViecDTO
                {
                    MaCongViec = cv.MaCongViec,
                    TenDangNhap = cv.TenDangNhap,
                    TieuDe = cv.TieuDe,
                    MoTa = cv.MoTa,
                    NgayHetHan = cv.NgayHetHan,
                    HoanThanh = cv.HoanThanh
                }).ToList();
        }

        // Lấy công việc theo MaCongViec
        public CongViecDTO GetByID(int maCongViec)
        {
            var congViec = qlcv.CongViecs
                .Where(cv => cv.MaCongViec == maCongViec)
                .Select(cv => new CongViecDTO
                {
                    MaCongViec = cv.MaCongViec,
                    TenDangNhap = cv.TenDangNhap,
                    TieuDe = cv.TieuDe,
                    MoTa = cv.MoTa,
                    NgayHetHan = cv.NgayHetHan,
                    HoanThanh = cv.HoanThanh
                })
                .FirstOrDefault();

            return congViec;
        }


        // Thêm công việc mới
        public bool Insert(CongViecDTO congViec)
        {
            try
            {
                var newCongViec = new CongViec
                {
                    TenDangNhap = congViec.TenDangNhap,
                    TieuDe = congViec.TieuDe,
                    MoTa = congViec.MoTa,
                    NgayHetHan = congViec.NgayHetHan,
                    HoanThanh = false
                };

                qlcv.CongViecs.InsertOnSubmit(newCongViec);
                qlcv.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xóa công việc
        public bool Delete(int maCongViec)
        {
            try
            {
                var congViecToDelete = qlcv.CongViecs.FirstOrDefault(cv => cv.MaCongViec == maCongViec);
                if (congViecToDelete != null)
                {
                    qlcv.CongViecs.DeleteOnSubmit(congViecToDelete);
                    qlcv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Cập nhật công việc
        public bool Update(CongViecDTO congViec)
        {
            try
            {
                var congViecToUpdate = qlcv.CongViecs.FirstOrDefault(cv => cv.MaCongViec == congViec.MaCongViec);
                if (congViecToUpdate != null)
                {
                    congViecToUpdate.TieuDe = congViec.TieuDe;
                    congViecToUpdate.MoTa = congViec.MoTa;
                    congViecToUpdate.NgayHetHan = congViec.NgayHetHan;
                    congViecToUpdate.HoanThanh = congViec.HoanThanh;

                    qlcv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateHoanThanh(int maCongViec, bool hoanThanh)
        {
            try
            {
                var congViecToUpdate = qlcv.CongViecs.FirstOrDefault(cv => cv.MaCongViec == maCongViec);
                if (congViecToUpdate != null)
                {
                    congViecToUpdate.HoanThanh = hoanThanh;
                    qlcv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
