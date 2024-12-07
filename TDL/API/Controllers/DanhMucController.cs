using System.Linq;
using System.Web.Http;
using BLL;
using DTO;

namespace API.Controllers
{
    [RoutePrefix("api/DanhMuc")]
    public class DanhMucController : ApiController
    {
        private readonly DanhMucBLL _danhMucBLL;

        public DanhMucController()
        {
            _danhMucBLL = new DanhMucBLL();
        }

        // GET: api/DanhMuc/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var danhMucs = _danhMucBLL.GetALL().ToList();
            return Ok(danhMucs);
        }

        // GET: api/DanhMuc/GetByTenDangNhap/{tenDangNhap}
        [HttpGet]
        [Route("GetByTenDangNhap/{tenDangNhap}")]
        public IHttpActionResult GetByTenDangNhap(string tenDangNhap)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
                return BadRequest("Tên đăng nhập không hợp lệ.");

            var danhMucs = _danhMucBLL.GetByTenDangNhap(tenDangNhap);
            return Ok(danhMucs);
        }

        // POST: api/DanhMuc/Insert
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert([FromBody] DanhMucDTO danhMucDTO)
        {
            if (danhMucDTO == null || string.IsNullOrWhiteSpace(danhMucDTO.TenDanhMuc))
                return BadRequest("Dữ liệu danh mục không hợp lệ.");

            var result = _danhMucBLL.Insert(danhMucDTO.TenDangNhap, danhMucDTO.TenDanhMuc);
            if (result)
                return Ok("Thêm danh mục thành công.");
            else
                return BadRequest("Không thể thêm danh mục.");
        }

        // PUT: api/DanhMuc/Update
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] DanhMucDTO danhMucDTO)
        {
            if (danhMucDTO == null || danhMucDTO.MaDanhMuc <= 0 || string.IsNullOrWhiteSpace(danhMucDTO.TenDanhMuc))
                return BadRequest("Dữ liệu danh mục không hợp lệ.");

            var result = _danhMucBLL.Update(danhMucDTO.MaDanhMuc, danhMucDTO.TenDanhMuc);
            if (result)
                return Ok("Cập nhật danh mục thành công.");
            else
                return BadRequest("Không thể cập nhật danh mục.");
        }

        // DELETE: api/DanhMuc/Delete/{maDanhMuc}
        [HttpDelete]
        [Route("Delete/{maDanhMuc:int}")]
        public IHttpActionResult Delete(int maDanhMuc)
        {
            if (maDanhMuc <= 0)
                return BadRequest("Mã danh mục không hợp lệ.");

            var result = _danhMucBLL.Delete(maDanhMuc);
            if (result)
                return Ok("Xóa danh mục thành công.");
            else
                return NotFound();
        }
    }
}
