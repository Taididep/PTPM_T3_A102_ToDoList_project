using DTO;
using System.Linq;

namespace DAL
{
    public class QL_PhanQuyenDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public QL_PhanQuyenDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.QL_PhanQuyens.Select(k => k);
        }
    }
}
