using System.Collections.Generic;
using BojLeave.Domain.Entities;

namespace BojLeave.Domain.Interfaces
{
    public interface ILeaveRepository
    {
        IEnumerable<Leave> GetAll();
        Leave? GetById(int id);
        void Add(Leave leave);
        void Update(Leave leave);
        void Delete(Leave leave);
        void SaveChanges();
    }
}
