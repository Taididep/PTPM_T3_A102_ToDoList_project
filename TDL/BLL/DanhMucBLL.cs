using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class DanhMucBLL
    {
        DanhMucDAL dalDanhMuc = new DanhMucDAL();
        public DanhMucBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalDanhMuc.GetALL();
        }
    }
}
