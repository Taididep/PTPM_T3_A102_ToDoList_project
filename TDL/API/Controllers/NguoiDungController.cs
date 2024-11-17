using BLL;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/NguoiDung")]
    public class NguoiDungController : ApiController
    {
        private QL_NguoiDungBLL _nguoiDungBLL;

        public NguoiDungController()
        {
            _nguoiDungBLL = new QL_NguoiDungBLL(); // Tạo đối tượng BLL
        }

        // GET api/NguoiDung/GetAll
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var users = _nguoiDungBLL.GetALL().ToList();
            return Ok(users); // Trả về danh sách người dùng
        }

        // GET api/NguoiDung/GetOne/{username}
        [HttpGet]
        [Route("GetOne/{username}")]
        public IHttpActionResult GetOne(string username)
        {
            var user = _nguoiDungBLL.GetOne(username);
            if (user == null)
            {
                return NotFound(); // Không tìm thấy người dùng
            }
            return Ok(user); // Trả về thông tin người dùng
        }

        // POST api/NguoiDung/Insert
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert([FromBody] QL_NguoiDung newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Dữ liệu không hợp lệ."); // Kiểm tra dữ liệu đầu vào
            }

            bool result = _nguoiDungBLL.Insert(newUser);
            if (result)
            {
                return CreatedAtRoute("GetOne", new { username = newUser.TenDangNhap }, newUser); // Tạo mới thành công
            }
            return BadRequest("Không thể tạo người dùng mới.");
        }

        // PUT api/NguoiDung/Update
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] QL_NguoiDung updatedUser)
        {
            if (updatedUser == null || string.IsNullOrEmpty(updatedUser.TenDangNhap))
            {
                return BadRequest("Dữ liệu không hợp lệ."); // Kiểm tra dữ liệu đầu vào
            }

            bool result = _nguoiDungBLL.Update(updatedUser);
            if (result)
            {
                return Ok(updatedUser); // Cập nhật thành công
            }
            return BadRequest("Không thể cập nhật người dùng.");
        }

        // DELETE api/NguoiDung/Delete/{username}
        [HttpDelete]
        [Route("Delete/{username}")]
        public IHttpActionResult Delete(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Tên đăng nhập không hợp lệ.");
            }

            bool result = _nguoiDungBLL.Delete(username);
            if (result)
            {
                return Ok("Xóa người dùng thành công.");
            }
            return NotFound(); // Không tìm thấy người dùng để xóa
        }

        // POST api/NguoiDung/Login
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody] QL_NguoiDungDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.TenDangNhap) || string.IsNullOrEmpty(request.MatKhau))
            {
                return Ok(new { message = "Invalid" });
            }

            var loginResult = _nguoiDungBLL.Check_User(request.TenDangNhap, request.MatKhau);

            if (loginResult == QL_NguoiDungBLL.LoginResult.Disabled)
            {
                return Ok(new { message = "Disabled" });
            }
            else if (loginResult == QL_NguoiDungBLL.LoginResult.Success)
            {
                return Ok(new { message = "Success" });
            }
            else
            {
                return StatusCode(System.Net.HttpStatusCode.InternalServerError); // Lỗi không xác định
            }

        }
    }
}
