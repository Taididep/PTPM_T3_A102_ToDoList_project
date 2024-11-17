using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DanhMucDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public DanhMucDAL() { }

        // Lấy tất cả danh mục
        public IQueryable<dynamic> GetALL()
        {
            return qlcv.DanhMucs.Select(k => k);
        }

        // Lấy danh sách danh mục theo TenDangNhap
        public List<DanhMucDTO> GetByTenDangNhap(string tenDangNhap)
        {
            return qlcv.DanhMucs
                       .Where(d => d.TenDangNhap == tenDangNhap)
                       .Select(d => new DanhMucDTO
                       {
                           MaDanhMuc = d.MaDanhMuc,
                           TenDanhMuc = d.TenDanhMuc,
                           TenDangNhap = d.TenDangNhap
                       }).ToList();
        }

        // Thêm danh mục mới
        public bool Insert(string tenDangNhap, string tenDanhMuc)
        {
            try
            {
                DanhMuc newDanhMuc = new DanhMuc
                {
                    TenDangNhap = tenDangNhap,
                    TenDanhMuc = tenDanhMuc
                };

                qlcv.DanhMucs.InsertOnSubmit(newDanhMuc);
                qlcv.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Xóa danh mục
        public bool Delete(int maDanhMuc)
        {
            try
            {
                var danhMucToDelete = qlcv.DanhMucs.FirstOrDefault(d => d.MaDanhMuc == maDanhMuc);
                if (danhMucToDelete != null)
                {
                    qlcv.DanhMucs.DeleteOnSubmit(danhMucToDelete);
                    qlcv.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy danh mục để xóa
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Cập nhật danh mục
        public bool Update(int maDanhMuc, string tenDanhMuc)
        {
            try
            {
                var danhMucToUpdate = qlcv.DanhMucs.FirstOrDefault(d => d.MaDanhMuc == maDanhMuc);
                if (danhMucToUpdate != null)
                {
                    danhMucToUpdate.TenDanhMuc = tenDanhMuc;
                    qlcv.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy danh mục để cập nhật
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
