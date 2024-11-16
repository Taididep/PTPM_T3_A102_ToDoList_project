using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongViecDTO
    {
        public int MaCongViec { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public bool HoanThanh { get; set; }
    }
}
