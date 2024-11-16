using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class QL_PhanQuyenBLL
    {
        QL_PhanQuyenDAL dalPhanQuyen = new QL_PhanQuyenDAL();
        public QL_PhanQuyenBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalPhanQuyen.GetALL();
        }
    }
}
