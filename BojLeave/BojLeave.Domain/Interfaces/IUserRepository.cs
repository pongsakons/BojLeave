using BojLeave.Domain.Entities;

namespace BojLeave.Domain.Interfaces
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}
