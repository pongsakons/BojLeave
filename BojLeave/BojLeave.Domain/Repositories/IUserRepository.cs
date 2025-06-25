using BojLeave.Domain.Entities;

namespace BojLeave.Domain.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}
