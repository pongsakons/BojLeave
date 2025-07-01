namespace BojLeave.Api.Models
{
    public class ApproveLeaveRequest
    {
        public int LeaveId { get; set; }
        public string? Status { get; set; } // Approved, Denied
    }
}
