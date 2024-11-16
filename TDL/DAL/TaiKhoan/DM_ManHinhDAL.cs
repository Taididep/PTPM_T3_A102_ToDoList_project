using DTO;
using System.Linq;

namespace DAL
{
    public class DM_ManHinhDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public DM_ManHinhDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.DM_ManHinhs.Select(k => k);
        }
    }
}
