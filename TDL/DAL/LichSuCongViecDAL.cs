using DTO;
using System.Linq;

namespace DAL
{
    public class LichSuCongViecDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public LichSuCongViecDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.LichSuCongViecs.Select(k => k);
        }
    }
}
