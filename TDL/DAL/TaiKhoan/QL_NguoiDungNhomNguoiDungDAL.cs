using DTO;
using System.Linq;

namespace DAL
{
    public class QL_NguoiDungNhomNguoiDungDAL
    {
        QLCONGVIECDataContext qlcv = new QLCONGVIECDataContext();
        public QL_NguoiDungNhomNguoiDungDAL() { }

        public IQueryable<dynamic> GetALL()
        {
            return qlcv.QL_NguoiDungNhomNguoiDungs.Select(k => k);
        }
    }
}
