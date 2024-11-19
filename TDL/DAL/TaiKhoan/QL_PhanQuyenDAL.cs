using DTO;
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
                p.MaNhomNguoiDung,
                p.MaManHinh,
                p.CoQuyen
            });
        }

        // Lấy phân quyền theo MaNhomNguoiDung và MaManHinh
        public QL_PhanQuyen GetOne(string maNhomNguoiDung, string maManHinh)
        {
            return qlcv.QL_PhanQuyens.FirstOrDefault(p =>
                p.MaNhomNguoiDung == maNhomNguoiDung && p.MaManHinh == maManHinh);
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
        public bool Delete(string maNhomNguoiDung, string maManHinh)
        {
            try
            {
                var phanQuyen = qlcv.QL_PhanQuyens.FirstOrDefault(p =>
                    p.MaNhomNguoiDung == maNhomNguoiDung && p.MaManHinh == maManHinh);
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
                var phanQuyen = qlcv.QL_PhanQuyens.FirstOrDefault(p =>
                    p.MaNhomNguoiDung == updatedPhanQuyen.MaNhomNguoiDung &&
                    p.MaManHinh == updatedPhanQuyen.MaManHinh);
                if (phanQuyen != null)
                {
                    phanQuyen.CoQuyen = updatedPhanQuyen.CoQuyen;
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
