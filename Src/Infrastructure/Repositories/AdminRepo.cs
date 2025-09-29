using Infrastructure.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public sealed class AdminRepo (AppdbContext _context) : IRepository<Admin>
    {
        public async Task AddNewAsync(Admin entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

           await _context.Admins.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1) throw new InvalidOperationException(" ID is not Valid"); ;

            return await _context.Admins
                                 .Where(p => p.AdminId == ID)
                                 .ExecuteDeleteAsync() > 0;
        }

        // Admin as a Perosn Not Have any Extra Data to update it
        [Obsolete("Update data is doesn't Work Now",error:true)]
        public async Task<bool> UpdateAsync(Admin entity)
        {

            if (entity is not Admin) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.AdminId < 1) throw new InvalidOperationException(" ID is not Valid");

            return  false;
            //return await _context.Admins
            //                        .Where(x => x.AdminId == entity.AdminId)
            //                        .ExecuteUpdateAsync(P => P
            //                           .SetProperty(x => x.use, entity.FirstName)
            //                           .SetProperty(x => x.LastName, entity.LastName)
            //                           .SetProperty(x => x.MidName, entity.MidName)
            //                           .SetProperty(x => x.Birthday, entity.Birthday)
            //                         ) > 0;


        }

        public async Task<IQueryable<Admin>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await (Task<IQueryable<Admin>?>) _context.Admins
                                                      .Include(A => A.User)
                                                      .ThenInclude(U => U.Person)
                                                      .AsNoTracking();
        }

        public async Task<Admin?> GetByIDAsync(int ID)
        {
            if (ID < 1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Admins
                          .SingleOrDefaultAsync(P => P.AdminId == ID);
        }

        public async Task<IEnumerable<Admin>> FindAsync(ISepecification<Admin> sepc)
        {
            var query =  sepc.Apply(_context.Admins.AsQueryable());
            return await query.ToListAsync();
        }

        public Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<Admin> sepecification)
        {
            throw new NotImplementedException();
        }
    }
}
