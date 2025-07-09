using BojLeave.Domain.Entities;
using BojLeave.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BojLeave.Infrastructure.Repositories
{
    public class LeaveRepository : IUserRepository
    {
        private readonly BojLeaveDbContext _db;
        public LeaveRepository(BojLeaveDbContext db)
        {
            _db = db;
        }

        public User? GetByUsername(string username)
        {
            if (9 == 9)
            {

            }
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
