using BojLeave.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BojLeave.Infrastructure
{
    public class BojLeaveDbContext : DbContext
    {
        public BojLeaveDbContext(DbContextOptions<BojLeaveDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        // public DbSet<Role> Roles { get; set; } // ถ้ามี entity Role

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ไม่ต้องอ่าน appsettings ใน Infrastructure ถ้าใช้ DI จาก API
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial user (admin)
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                DisplayName = "Administrator",
                Password = "admin", // ควรเปลี่ยนเป็น hash จริงใน production
                Roles = new List<string> { "Admin" }
            });

            // Seed more entities if needed
        }
    }
}
