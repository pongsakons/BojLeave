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
            // Demo: return a static list with leave days
            return Ok(new[]
            {
                new { Id = 1, Type = "Sick", From = "2025-07-01", To = "2025-07-02", Days = 2, Status = "Approved" },
                new { Id = 2, Type = "Vacation", From = "2025-08-10", To = "2025-08-15", Days = 6, Status = "Pending" }
            });
        }

        [HttpPost]
        public IActionResult RequestLeave([FromBody] LeaveRequest request)
        {
            // Demo: accept any request
            return Ok(new { Success = true, Message = "Leave requested." });
        }

        [HttpPost("approve")]
        public IActionResult ApproveLeave([FromBody] ApproveLeaveRequest request)
        {
            // Demo: approve/deny leave
            // Normally, you would update the leave status in the database here
            return Ok(new { Success = true, Message = $"Leave {request.Status}" });
        }
    }
}
