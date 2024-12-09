using BLL;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/CongViecDanhMuc")]
    public class CongViecDanhMucController : ApiController
    {
        private readonly CongViecDanhMucBLL _congViecDanhMucBLL;

        public CongViecDanhMucController()
        {
            _congViecDanhMucBLL = new CongViecDanhMucBLL();
        }

        // GET: api/CongViecDanhMuc/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var danhSach = _congViecDanhMucBLL.GetAll();
            if (danhSach == null || !danhSach.Any())
                return NotFound();
            return Ok(danhSach);
        }

        // GET: api/CongViecDanhMuc/GetByMaCongViec/{maCongViec}
        [HttpGet]
        [Route("GetByMaCongViec/{maCongViec:int}")]
        public IHttpActionResult GetByMaCongViec(int maCongViec)
        {
            if (maCongViec <= 0)
                return BadRequest("Mã công việc không hợp lệ.");

            var danhSach = _congViecDanhMucBLL.GetByMaCongViec(maCongViec);
            if (danhSach == null || !danhSach.Any())
                return NotFound();
            return Ok(danhSach);
        }

        // GET: api/CongViecDanhMuc/GetByMaDanhMuc/{maDanhMuc}
        [HttpGet]
        [Route("GetByMaDanhMuc/{maDanhMuc:int}")]
        public IHttpActionResult GetByMaDanhMuc(int maDanhMuc)
        {
            if (maDanhMuc <= 0)
                return BadRequest("Mã danh mục không hợp lệ.");

            var danhSach = _congViecDanhMucBLL.GetByMaDanhMuc(maDanhMuc);
            if (danhSach == null || !danhSach.Any())
                return NotFound();
            return Ok(danhSach);
        }

        // POST: api/CongViecDanhMuc/Insert
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert([FromBody] CongViecDanhMucDTO cvdmDTO)
        {
            if (cvdmDTO == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = _congViecDanhMucBLL.Insert(cvdmDTO);
            if (result)
                return Ok("Thêm liên kết công việc - danh mục thành công.");
            else
                return BadRequest("Không thể thêm liên kết công việc - danh mục.");
        }

        // PUT: api/CongViecDanhMuc/Update
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] CongViecDanhMucDTO cvdmDTO)
        {
            if (cvdmDTO == null)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = _congViecDanhMucBLL.Update(cvdmDTO);
            if (result)
                return Ok("Cập nhật liên kết công việc - danh mục thành công.");
            else
                return BadRequest("Không thể cập nhật liên kết công việc - danh mục.");
        }

        // DELETE: api/CongViecDanhMuc/Delete/{maCongViec}/{maDanhMuc}
        [HttpDelete]
        [Route("Delete/{maCongViec:int}/{maDanhMuc:int}")]
        public IHttpActionResult Delete(int maCongViec, int maDanhMuc)
        {
            if (maCongViec <= 0 || maDanhMuc <= 0)
                return BadRequest("Dữ liệu không hợp lệ.");

            var result = _congViecDanhMucBLL.Delete(maCongViec, maDanhMuc);
            if (result)
                return Ok("Xóa liên kết công việc - danh mục thành công.");
            else
                return NotFound();
        }
    }
}
