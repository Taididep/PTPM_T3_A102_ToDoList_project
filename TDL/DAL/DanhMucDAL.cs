using DTO;
using System.Linq;

namespace DAL
{
    public class DanhMucDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public DanhMucDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.DanhMucs.Select(k => k);
        }
    }
}
