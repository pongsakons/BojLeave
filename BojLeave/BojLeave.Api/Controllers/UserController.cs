using BojLeave.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BojLeave.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // ตัวอย่าง: save user หรือ logic อื่น ๆ
            return Ok(new { message = "User is valid!" });
        }
    }
}
