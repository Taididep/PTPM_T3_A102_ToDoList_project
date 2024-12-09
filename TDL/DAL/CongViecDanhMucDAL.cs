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
            return qlcv.CongViecDanhMucs
                .Join(qlcv.DanhMucs,
                      cvdm => cvdm.MaDanhMuc,
                      dm => dm.MaDanhMuc,
                      (cvdm, dm) => new CongViecDanhMucDTO
                      {
                          MaCongViec = cvdm.MaCongViec,
                          MaDanhMuc = cvdm.MaDanhMuc,
                          TenDanhMuc = dm.TenDanhMuc // Lấy tên danh mục từ bảng DanhMuc
                      })
                .ToList();
        }


        // Lấy danh sách theo MaCongViec
        public List<CongViecDanhMucDTO> GetByMaCongViec(int maCongViec)
        {
            return qlcv.CongViecDanhMucs
                .Where(cvdm => cvdm.MaCongViec == maCongViec)
                .Join(qlcv.DanhMucs,
                      cvdm => cvdm.MaDanhMuc,
                      dm => dm.MaDanhMuc,
                      (cvdm, dm) => new CongViecDanhMucDTO
                      {
                          MaCongViec = cvdm.MaCongViec,
                          MaDanhMuc = cvdm.MaDanhMuc,
                          TenDanhMuc = dm.TenDanhMuc // Lấy tên danh mục từ bảng DanhMuc
                      })
                .ToList();
        }


        // Lấy danh sách theo MaDanhMuc
        public List<CongViecDanhMucDTO> GetByMaDanhMuc(int maDanhMuc)
        {
            return qlcv.CongViecDanhMucs
                .Where(cvdm => cvdm.MaDanhMuc == maDanhMuc)
                .Join(qlcv.DanhMucs,
                      cvdm => cvdm.MaDanhMuc,
                      dm => dm.MaDanhMuc,
                      (cvdm, dm) => new CongViecDanhMucDTO
                      {
                          MaCongViec = cvdm.MaCongViec,
                          MaDanhMuc = cvdm.MaDanhMuc,
                          TenDanhMuc = dm.TenDanhMuc // Lấy tên danh mục từ bảng DanhMuc
                      })
                .ToList();
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
