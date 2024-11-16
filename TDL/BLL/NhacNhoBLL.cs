using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class NhacNhoBLL
    {
        NhacNhoDAL dalNhacNho = new NhacNhoDAL();
        public NhacNhoBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalNhacNho.GetALL();
        }


    }
}
