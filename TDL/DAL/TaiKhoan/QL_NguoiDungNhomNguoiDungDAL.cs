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
                n.Id,
                n.TenDangNhap,
                n.MaNhom
            });
        }

        // Lấy thông tin một người dùng thuộc nhóm theo ID
        public QL_NguoiDungNhomNguoiDung GetOne(int id)
        {
            return qlcv.QL_NguoiDungNhomNguoiDungs.FirstOrDefault(n => n.Id == id);
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

        // Xóa quan hệ người dùng - nhóm người dùng theo ID
        public bool Delete(int id)
        {
            try
            {
                var nguoiDungNhom = qlcv.QL_NguoiDungNhomNguoiDungs.FirstOrDefault(n => n.Id == id);
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
                var nguoiDungNhom = qlcv.QL_NguoiDungNhomNguoiDungs.FirstOrDefault(n => n.Id == updatedNguoiDungNhom.Id);
                if (nguoiDungNhom != null)
                {
                    nguoiDungNhom.TenDangNhap = updatedNguoiDungNhom.TenDangNhap;
                    nguoiDungNhom.MaNhom = updatedNguoiDungNhom.MaNhom;
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
