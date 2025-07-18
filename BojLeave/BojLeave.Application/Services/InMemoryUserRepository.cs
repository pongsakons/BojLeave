using BojLeave.Domain.Entities;
using BojLeave.Domain.Repositories;

namespace BojLeave.Application
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "demo", DisplayName = "Demo User", Roles = new List<string> { "User" } },
            new User { Id = 2, Username = "admin", DisplayName = "Admin", Roles = new List<string> { "Admin", "User" } }
        };

        public User? GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
