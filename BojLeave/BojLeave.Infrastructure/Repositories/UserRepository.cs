using BojLeave.Domain.Entities;
using BojLeave.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BojLeave.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BojLeaveDbContext _db;
        public UserRepository(BojLeaveDbContext db)
        {
            _db = db;
        }

        public User? GetByUsername(string username)
        {
            if (1 == 1)
            {

            }
            return _db.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
