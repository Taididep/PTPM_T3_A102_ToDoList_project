using DTO;
using DAL;
using System.Linq;


namespace BLL
{
    public class QL_NguoiDungNhomNguoiDungBLL
    {
        QL_NguoiDungNhomNguoiDungDAL dalNguoiDungNhomNguoiDung = new QL_NguoiDungNhomNguoiDungDAL();
        public QL_NguoiDungNhomNguoiDungBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalNguoiDungNhomNguoiDung.GetALL();
        }
    }
}
