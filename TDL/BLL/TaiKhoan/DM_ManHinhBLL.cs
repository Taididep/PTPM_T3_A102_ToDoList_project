using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class DM_ManHinhBLL
    {
        DM_ManHinhDAL dalManHinh = new DM_ManHinhDAL();
        public DM_ManHinhBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalManHinh.GetALL();
        }
    }
}
