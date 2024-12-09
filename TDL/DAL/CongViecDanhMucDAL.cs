using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class CongViecDanhMucDAL
    {
        private readonly QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public CongViecDanhMucDAL() { }

        // Lấy danh sách tất cả Công Việc - Danh Mục
        public List<CongViecDanhMucDTO> GetAll()
        {
            return qlcv.CongViecDanhMucs.Select(cvdm => new CongViecDanhMucDTO
            {
                MaCongViec = cvdm.MaCongViec,
                MaDanhMuc = cvdm.MaDanhMuc
            }).ToList();
        }

        // Lấy danh sách theo MaCongViec
        public List<CongViecDanhMucDTO> GetByMaCongViec(int maCongViec)
        {
            return qlcv.CongViecDanhMucs
                .Where(cvdm => cvdm.MaCongViec == maCongViec)
                .Select(cvdm => new CongViecDanhMucDTO
                {
                    MaCongViec = cvdm.MaCongViec,
                    MaDanhMuc = cvdm.MaDanhMuc
                }).ToList();
        }

        // Lấy danh sách theo MaDanhMuc
        public List<CongViecDanhMucDTO> GetByMaDanhMuc(int maDanhMuc)
        {
            return qlcv.CongViecDanhMucs
                .Where(cvdm => cvdm.MaDanhMuc == maDanhMuc)
                .Select(cvdm => new CongViecDanhMucDTO
                {
                    MaCongViec = cvdm.MaCongViec,
                    MaDanhMuc = cvdm.MaDanhMuc
                }).ToList();
        }

        // Thêm mới Công Việc - Danh Mục
        public bool Insert(CongViecDanhMucDTO cvdmDTO)
        {
            try
            {
                var newCVDM = new CongViecDanhMuc
                {
                    MaCongViec = cvdmDTO.MaCongViec,
                    MaDanhMuc = cvdmDTO.MaDanhMuc
                };

                qlcv.CongViecDanhMucs.InsertOnSubmit(newCVDM);
                qlcv.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Xóa Công Việc - Danh Mục theo MaCongViec và MaDanhMuc
        public bool Delete(int maCongViec, int maDanhMuc)
        {
            try
            {
                var cvdmToDelete = qlcv.CongViecDanhMucs
                    .FirstOrDefault(cvdm => cvdm.MaCongViec == maCongViec && cvdm.MaDanhMuc == maDanhMuc);

                if (cvdmToDelete != null)
                {
                    qlcv.CongViecDanhMucs.DeleteOnSubmit(cvdmToDelete);
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

        // Cập nhật Công Việc - Danh Mục
        public bool Update(CongViecDanhMucDTO cvdmDTO)
        {
            try
            {
                var cvdmToUpdate = qlcv.CongViecDanhMucs
                    .FirstOrDefault(cvdm => cvdm.MaCongViec == cvdmDTO.MaCongViec && cvdm.MaDanhMuc == cvdmDTO.MaDanhMuc);

                if (cvdmToUpdate != null)
                {
                    cvdmToUpdate.MaCongViec = cvdmDTO.MaCongViec;
                    cvdmToUpdate.MaDanhMuc = cvdmDTO.MaDanhMuc;

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
