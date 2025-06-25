using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BojLeave.Api.Models;

namespace BojLeave.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LeaveController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLeaves()
        {
            // Demo: return a static list
            return Ok(new[]
            {
                new { Id = 1, Type = "Sick", From = "2025-07-01", To = "2025-07-02", Status = "Approved" },
                new { Id = 2, Type = "Vacation", From = "2025-08-10", To = "2025-08-15", Status = "Pending" }
            });
        }

        [HttpPost]
        public IActionResult RequestLeave([FromBody] LeaveRequest request)
        {
            // Demo: accept any request
            return Ok(new { Success = true, Message = "Leave requested." });
        }
    }
}
