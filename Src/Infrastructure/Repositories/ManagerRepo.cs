using Infrastructure.Data;
using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class ManagerRepo : IRepository<Manager>
    {
        readonly AppdbContext _context;

        public ManagerRepo(AppdbContext context)
        {
            _context = context;
        }


        public async Task AddNewAsync(Manager entity)
        {
            if (entity is not Manager) throw new NullReferenceException("User Object doesn't Exist"); ;

            await _context.Managers.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1) throw new InvalidOperationException(" ID is not Valid"); ;

            return await _context.Managers
                .Where(p => p.ManagerId == ID)
                .ExecuteDeleteAsync() > 0;
        }

        [Obsolete("Update data is doesn't Work Now", error: true)]
        public async Task<bool> UpdateAsync(Manager entity)
        {

            if (entity is not Manager) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.ManagerId < 1) throw new InvalidOperationException(" ID is not Valid");

            return await _context.Managers
                                    .Where(x => x.UserId == entity.UserId)
                                    .ExecuteUpdateAsync(p => p) > 0;
        }

        public async Task<List<ManagerView>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await _context.ManagerViews
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Manager?> GetByIDAsync(int ID)
        {
            if (ID < 1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Managers
                          .SingleOrDefaultAsync(P => P.ManagerId == ID);
        }

    }
}
