using BojLeave.Domain.Repositories;
using BojLeave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BojLeave.Infrastructure.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly BojLeaveDbContext _db;
        public SqlUserRepository(BojLeaveDbContext db)
        {
            _db = db;
        }

        public User? GetByUsername(string username)
        {
            return _db.Users.Include(u => u.Roles).FirstOrDefault(u => u.Username == username);
        }
    }
}
