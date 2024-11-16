using DTO;
using DAL;
using System.Linq;


namespace BLL
{
    public class QL_NhomNguoiDungBLL
    {
        QL_NhomNguoiDungDAL dalNhomNguoiDung = new QL_NhomNguoiDungDAL();
        public QL_NhomNguoiDungBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalNhomNguoiDung.GetALL();
        }
    }
}
