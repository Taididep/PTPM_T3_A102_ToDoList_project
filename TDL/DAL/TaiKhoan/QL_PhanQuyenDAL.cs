﻿using DTO;
using System.Linq;

namespace DAL
{
    public class QL_PhanQuyenDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public QL_PhanQuyenDAL() { }

        // Lấy danh sách phân quyền
        public IQueryable<dynamic> GetAll()
        {
            return qlcv.QL_PhanQuyens.Select(p => new
            {
                p.Id,
                p.MaNhom,
                p.MaManHinh,
                p.Quyen
            });
        }

        // Lấy phân quyền theo ID
        public QL_PhanQuyen GetOne(int id)
        {
            return qlcv.QL_PhanQuyens.FirstOrDefault(p => p.Id == id);
        }

        // Thêm phân quyền mới
        public bool Insert(QL_PhanQuyen phanQuyen)
        {
            try
            {
                qlcv.QL_PhanQuyens.InsertOnSubmit(phanQuyen);
                qlcv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa phân quyền
        public bool Delete(int id)
        {
            try
            {
                var phanQuyen = qlcv.QL_PhanQuyens.FirstOrDefault(p => p.Id == id);
                if (phanQuyen != null)
                {
                    qlcv.QL_PhanQuyens.DeleteOnSubmit(phanQuyen);
                    qlcv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật phân quyền
        public bool Update(QL_PhanQuyen updatedPhanQuyen)
        {
            try
            {
                var phanQuyen = qlcv.QL_PhanQuyens.FirstOrDefault(p => p.Id == updatedPhanQuyen.Id);
                if (phanQuyen != null)
                {
                    phanQuyen.MaNhom = updatedPhanQuyen.MaNhom;
                    phanQuyen.MaManHinh = updatedPhanQuyen.MaManHinh;
                    phanQuyen.Quyen = updatedPhanQuyen.Quyen;
                    qlcv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
