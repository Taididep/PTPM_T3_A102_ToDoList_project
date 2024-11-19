using DTO;
using System.Linq;

namespace DAL
{
    public class QL_NguoiDungNhomNguoiDungDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public QL_NguoiDungNhomNguoiDungDAL() { }

        // Lấy danh sách tất cả người dùng thuộc nhóm người dùng
        public IQueryable<dynamic> GetAll()
        {
            return qlcv.QL_NguoiDungNhomNguoiDungs.Select(n => new
            {
                n.TenDangNhap,
                n.MaNhomNguoiDung,
                n.GhiChu
            });
        }

        // Lấy thông tin một người dùng thuộc nhóm theo TenDangNhap và MaNhomNguoiDung
        public QL_NguoiDungNhomNguoiDung GetOne(string tenDangNhap, string maNhomNguoiDung)
        {
            return qlcv.QL_NguoiDungNhomNguoiDungs
                .FirstOrDefault(n => n.TenDangNhap == tenDangNhap && n.MaNhomNguoiDung == maNhomNguoiDung);
        }

        // Thêm mới quan hệ người dùng - nhóm người dùng
        public bool Insert(QL_NguoiDungNhomNguoiDung nguoiDungNhom)
        {
            try
            {
                qlcv.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(nguoiDungNhom);
                qlcv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa quan hệ người dùng - nhóm người dùng theo TenDangNhap và MaNhomNguoiDung
        public bool Delete(string tenDangNhap, string maNhomNguoiDung)
        {
            try
            {
                var nguoiDungNhom = qlcv.QL_NguoiDungNhomNguoiDungs
                    .FirstOrDefault(n => n.TenDangNhap == tenDangNhap && n.MaNhomNguoiDung == maNhomNguoiDung);
                if (nguoiDungNhom != null)
                {
                    qlcv.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(nguoiDungNhom);
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

        // Cập nhật quan hệ người dùng - nhóm người dùng
        public bool Update(QL_NguoiDungNhomNguoiDung updatedNguoiDungNhom)
        {
            try
            {
                var nguoiDungNhom = qlcv.QL_NguoiDungNhomNguoiDungs
                    .FirstOrDefault(n => n.TenDangNhap == updatedNguoiDungNhom.TenDangNhap
                                      && n.MaNhomNguoiDung == updatedNguoiDungNhom.MaNhomNguoiDung);
                if (nguoiDungNhom != null)
                {
                    nguoiDungNhom.GhiChu = updatedNguoiDungNhom.GhiChu;
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
