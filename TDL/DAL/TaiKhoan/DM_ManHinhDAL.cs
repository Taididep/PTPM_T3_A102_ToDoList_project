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
                m.Id,
                m.TenManHinh,
                m.MoTa
            });
        }

        // Lấy thông tin một màn hình theo Id
        public DM_ManHinh GetOne(int id)
        {
            return qlcv.DM_ManHinhs.FirstOrDefault(m => m.Id == id);
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

        // Xóa một màn hình
        public bool Delete(int id)
        {
            try
            {
                var manHinh = qlcv.DM_ManHinhs.FirstOrDefault(m => m.Id == id);
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
                var manHinh = qlcv.DM_ManHinhs.FirstOrDefault(m => m.Id == updatedManHinh.Id);
                if (manHinh != null)
                {
                    manHinh.TenManHinh = updatedManHinh.TenManHinh;
                    manHinh.MoTa = updatedManHinh.MoTa;
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
