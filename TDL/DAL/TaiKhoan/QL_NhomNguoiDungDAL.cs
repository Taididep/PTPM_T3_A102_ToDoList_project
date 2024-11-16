using DTO;
using System.Linq;

namespace DAL
{
    public class QL_NhomNguoiDungDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public QL_NhomNguoiDungDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.QL_NhomNguoiDungs.Select(k => k);
        }
    }
}
