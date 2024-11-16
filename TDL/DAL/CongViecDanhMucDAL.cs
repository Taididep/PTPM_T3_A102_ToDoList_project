using DTO;
using System.Linq;

namespace DAL
{
    public class CongViecDanhMucDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public CongViecDanhMucDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.CongViecDanhMucs.Select(k => k);
        }

    }
}
