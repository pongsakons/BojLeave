using BojLeave.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BojLeave.Infrastructure
{
    public class BojLeaveDbContext : DbContext
    {
        public BojLeaveDbContext(DbContextOptions<BojLeaveDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        // public DbSet<Role> Roles { get; set; } // ถ้ามี entity Role
    }
}
