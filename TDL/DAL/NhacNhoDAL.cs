using DTO;
using System.Linq;

namespace DAL
{
    public class NhacNhoDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public NhacNhoDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.NhacNhos.Select(k => k);
        }
    }
}
