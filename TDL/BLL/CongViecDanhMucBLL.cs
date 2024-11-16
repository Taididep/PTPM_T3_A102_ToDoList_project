using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class CongViecDanhMucBLL
    {
        CongViecDanhMucDAL dalCongViecDanhMuc = new CongViecDanhMucDAL();
        public CongViecDanhMucBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalCongViecDanhMuc.GetALL();
        }
    }
}
