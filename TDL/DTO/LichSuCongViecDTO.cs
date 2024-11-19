using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichSuCongViecDTO
    {
        public int MaLichSu { get; set; }
        public int MaCongViec { get; set; }
        public DateTime NgayThayDoi { get; set; }
        public bool? TrangThaiCu { get; set; }
        public bool? TrangThaiMoi { get; set; }
    }

}
