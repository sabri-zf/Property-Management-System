using Infrastructure.Data;
using Domain.Interfaces;

namespace Infrastructure.Unit_Of_Work
{
    public class UnitOfWork(AppdbContext _context) : IUnitOfWork
    {
        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
