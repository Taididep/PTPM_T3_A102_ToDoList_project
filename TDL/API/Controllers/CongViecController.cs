using BLL;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/CongViec")]
    public class CongViecController : ApiController
    {
        private readonly CongViecBLL _congViecBLL;

        public CongViecController()
        {
            _congViecBLL = new CongViecBLL();
        }

        // GET: api/CongViec/GetByTenDangNhap/{tenDangNhap}
        [HttpGet]
        [Route("GetByTenDangNhap/{tenDangNhap}")]
        public IHttpActionResult GetByTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
                return BadRequest("Tên đăng nhập không hợp lệ.");

            var congViecs = _congViecBLL.GetByTenDangNhap(tenDangNhap);
            return Ok(congViecs);
        }

        // GET: api/CongViec/GetByTenDangNhapAndDanhMuc/{maDanhMuc}/{tenDangNhap}
        [HttpGet]
        [Route("GetByTenDangNhapAndDanhMuc/{maDanhMuc:int}/{tenDangNhap}")]
        public IHttpActionResult GetByTenDangNhapAndDanhMuc(int maDanhMuc, string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                return BadRequest("Tên đăng nhập không được trống.");
            }

            var congViecs = _congViecBLL.GetByTenDangNhapAndDanhMuc(tenDangNhap, maDanhMuc);

            if (congViecs == null || !congViecs.Any())
            {
                return NotFound();
            }

            return Ok(congViecs);
        }


        // GET: api/CongViec/GetByID/{maCongViec}
        [HttpGet]
        [Route("GetByID/{maCongViec:int}")]
        public IHttpActionResult GetByID(int maCongViec)
        {
            if (maCongViec <= 0)
                return BadRequest("Mã công việc không hợp lệ.");

            var congViec = _congViecBLL.GetByID(maCongViec);
            if (congViec == null)
                return NotFound();

            return Ok(congViec);
        }


        // POST: api/CongViec/Insert
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert([FromBody] CongViecDTO congViec)
        {
            if (congViec == null)
                return BadRequest("Dữ liệu công việc không hợp lệ.");

            var result = _congViecBLL.Insert(congViec);
            if (result)
                return Ok("Thêm công việc thành công.");
            else
                return BadRequest("Không thể thêm công việc.");
        }

        // PUT: api/CongViec/Update
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] CongViecDTO congViec)
        {
            if (congViec == null || congViec.MaCongViec <= 0)
                return BadRequest("Dữ liệu công việc không hợp lệ.");

            var result = _congViecBLL.Update(congViec);
            if (result)
                return Ok("Cập nhật công việc thành công.");
            else
                return BadRequest("Không thể cập nhật công việc.");
        }

        [HttpPut]
        [Route("UpdateHoanThanh/{maCongViec:int}/{hoanThanh:bool}")]
        public IHttpActionResult UpdateHoanThanh(int maCongViec, bool hoanThanh)
        {
            var result = _congViecBLL.UpdateHoanThanh(maCongViec, hoanThanh);
            if (result)
                return Ok("Cập nhật trạng thái công việc thành công.");
            else
                return BadRequest("Không thể cập nhật trạng thái công việc.");
        }




        // DELETE: api/CongViec/Delete/{maCongViec}
        [HttpDelete]
        [Route("Delete/{maCongViec:int}")]
        public IHttpActionResult Delete(int maCongViec)
        {
            if (maCongViec <= 0)
                return BadRequest("Mã công việc không hợp lệ.");

            var result = _congViecBLL.Delete(maCongViec);
            if (result)
                return Ok("Xóa công việc thành công.");
            else
                return NotFound();
        }
    }
}
