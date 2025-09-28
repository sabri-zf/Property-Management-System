using Infrastructure.Data;
using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class TenantRepo:IRepository<Tenant>
    {
        readonly AppdbContext _context;

        public TenantRepo(AppdbContext context)
        {
            _context = context;
        }


        public async Task AddNewAsync(Tenant entity)
        {
            if (entity is not Tenant) throw new NullReferenceException("User Object doesn't Exist"); ;

            await _context.Tenants.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1) throw new InvalidOperationException(" ID is not Valid"); ;

            return await _context.Tenants
                .Where(p => p.TenantId == ID)
                .ExecuteDeleteAsync() > 0;
        }

        [Obsolete("Update data is doesn't Work Now", error: true)]
        public async Task<bool> UpdateAsync(Tenant entity)
        {

            if (entity is not Tenant) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.TenantId < 1) throw new InvalidOperationException(" ID is not Valid");

            return await _context.Tenants
                                    .Where(x => x.TenantId == entity.TenantId)
                                    .ExecuteUpdateAsync(p => p) > 0;
        }

        public async Task<List<TenantView>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await _context.TenantViews
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Tenant?> GetByIDAsync(int ID)
        {
            if (ID < 1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Tenants
                                 .SingleOrDefaultAsync(P => P.TenantId == ID);
        }
    }
}
