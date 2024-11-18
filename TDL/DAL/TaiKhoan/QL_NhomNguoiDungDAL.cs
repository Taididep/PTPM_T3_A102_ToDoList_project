using DTO;
using System.Linq;

namespace DAL
{
    public class QL_NhomNguoiDungDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public QL_NhomNguoiDungDAL() { }

        // Lấy danh sách tất cả nhóm người dùng
        public IQueryable<dynamic> GetAll()
        {
            return qlcv.QL_NhomNguoiDungs.Select(n => new
            {
                n.MaNhom,
                n.TenNhom,
                n.MoTa
            });
        }

        // Lấy thông tin một nhóm người dùng theo mã nhóm
        public QL_NhomNguoiDung GetOne(string maNhom)
        {
            return qlcv.QL_NhomNguoiDungs.FirstOrDefault(n => n.MaNhom == maNhom);
        }

        // Thêm một nhóm người dùng mới
        public bool Insert(QL_NhomNguoiDung nhomNguoiDung)
        {
            try
            {
                qlcv.QL_NhomNguoiDungs.InsertOnSubmit(nhomNguoiDung);
                qlcv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa một nhóm người dùng
        public bool Delete(string maNhom)
        {
            try
            {
                var nhomNguoiDung = qlcv.QL_NhomNguoiDungs.FirstOrDefault(n => n.MaNhom == maNhom);
                if (nhomNguoiDung != null)
                {
                    qlcv.QL_NhomNguoiDungs.DeleteOnSubmit(nhomNguoiDung);
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

        // Cập nhật thông tin một nhóm người dùng
        public bool Update(QL_NhomNguoiDung updatedNhomNguoiDung)
        {
            try
            {
                var nhomNguoiDung = qlcv.QL_NhomNguoiDungs.FirstOrDefault(n => n.MaNhom == updatedNhomNguoiDung.MaNhom);
                if (nhomNguoiDung != null)
                {
                    nhomNguoiDung.TenNhom = updatedNhomNguoiDung.TenNhom;
                    nhomNguoiDung.MoTa = updatedNhomNguoiDung.MoTa;
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
