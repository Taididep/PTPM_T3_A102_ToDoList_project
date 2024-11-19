using DTO;
using System.Linq;

namespace DAL
{
    public class DM_ManHinhDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();

        public DM_ManHinhDAL() { }

        // Lấy danh sách tất cả màn hình
        public IQueryable<dynamic> GetAll()
        {
            return qlcv.DM_ManHinhs.Select(m => new
            {
                m.MaManHinh,
                m.TenManHinh
            });
        }

        // Lấy thông tin một màn hình theo MaManHinh
        public DM_ManHinh GetOne(string maManHinh)
        {
            return qlcv.DM_ManHinhs.FirstOrDefault(m => m.MaManHinh == maManHinh);
        }

        // Thêm một màn hình mới
        public bool Insert(DM_ManHinh manHinh)
        {
            try
            {
                qlcv.DM_ManHinhs.InsertOnSubmit(manHinh);
                qlcv.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa một màn hình theo MaManHinh
        public bool Delete(string maManHinh)
        {
            try
            {
                var manHinh = qlcv.DM_ManHinhs.FirstOrDefault(m => m.MaManHinh == maManHinh);
                if (manHinh != null)
                {
                    qlcv.DM_ManHinhs.DeleteOnSubmit(manHinh);
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

        // Cập nhật thông tin một màn hình
        public bool Update(DM_ManHinh updatedManHinh)
        {
            try
            {
                var manHinh = qlcv.DM_ManHinhs.FirstOrDefault(m => m.MaManHinh == updatedManHinh.MaManHinh);
                if (manHinh != null)
                {
                    manHinh.TenManHinh = updatedManHinh.TenManHinh;
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
