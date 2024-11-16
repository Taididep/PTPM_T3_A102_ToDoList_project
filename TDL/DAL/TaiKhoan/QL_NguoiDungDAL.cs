using DTO;
using System.Linq;

namespace DAL
{
    public class QL_NguoiDungDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public QL_NguoiDungDAL() { }

        // Lấy danh sách tất cả người dùng
        public IQueryable<dynamic> GetALL()
        {
            return qlcv.QL_NguoiDungs.Select(k => new
            {
                k.TenDangNhap,
                k.MatKhau,
                k.HoatDong
            });
        }

        // Lấy thông tin một người dùng theo tên đăng nhập
        public QL_NguoiDung GetOne(string tenDangNhap)
        {
            return qlcv.QL_NguoiDungs
                       .Where(k => k.TenDangNhap == tenDangNhap)
                       .FirstOrDefault();
        }


        // Thêm một người dùng mới
        public bool Insert(QL_NguoiDung nguoiDung)
        {
            try
            {
                qlcv.QL_NguoiDungs.InsertOnSubmit(nguoiDung);
                qlcv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa một người dùng
        public bool Delete(string tenDangNhap)
        {
            try
            {
                var nguoiDung = qlcv.QL_NguoiDungs.FirstOrDefault(k => k.TenDangNhap == tenDangNhap);
                if (nguoiDung != null)
                {
                    qlcv.QL_NguoiDungs.DeleteOnSubmit(nguoiDung);
                    qlcv.SubmitChanges();
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy người dùng
            }
            catch
            {
                return false; // Lỗi khi xóa
            }
        }

        // Cập nhật thông tin một người dùng
        public bool Update(QL_NguoiDung updatedNguoiDung)
        {
            try
            {
                var nguoiDung = qlcv.QL_NguoiDungs.FirstOrDefault(k => k.TenDangNhap == updatedNguoiDung.TenDangNhap);
                if (nguoiDung != null)
                {
                    nguoiDung.MatKhau = updatedNguoiDung.MatKhau;
                    nguoiDung.HoatDong = updatedNguoiDung.HoatDong;
                    qlcv.SubmitChanges();
                    return true; // Cập nhật thành công
                }
                return false; // Không tìm thấy người dùng
            }
            catch
            {
                return false; // Lỗi khi cập nhật
            }
        }


    }
}
