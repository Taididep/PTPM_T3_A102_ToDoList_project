using DTO;
using DAL;
using System.Linq;

namespace BLL
{
    public class LichSuCongViecBLL
    {
        LichSuCongViecDAL dalLichSuCongViec = new LichSuCongViecDAL();
        public LichSuCongViecBLL() { }

        public IQueryable<dynamic> GetALL()
        {
            return dalLichSuCongViec.GetALL();
        }
    }
}
