using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class UserRepo : IRepository<User>,IUserServers
    {

        readonly AppdbContext _context;

        public UserRepo(AppdbContext context)
        {
            _context = context;
        }


        public async Task AddNewAsync(User entity)
        {
            if(entity is not User) throw new NullReferenceException("User Object doesn't Exist"); ;

            await _context.Users.AddAsync(entity);
        }
        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1 ) throw new InvalidOperationException(" ID is not Valid"); ;

            return  await _context.Users
                .Where(p => p.UserId == ID)
                .ExecuteDeleteAsync() > 0;
        }
        public async Task<bool> UpdateAsync(User entity)
        {

            if (entity is not User) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.UserId < 1) throw new InvalidOperationException(" ID is not Valid");

         return await _context.Users
                                 .Where(x => x.UserId == entity.UserId)
                                 .Include(x => x.Person)
                                 .ExecuteUpdateAsync(P => P
                                    .SetProperty(x =>  x.Username, entity.Username)
                                    .SetProperty(x => x.Password, entity.Password)
                                    .SetProperty(x => x.Person.updateAt, entity.Person.updateAt)
                                    .SetProperty(x => x.IsActive, entity.IsActive)
                                  ) > 0;  
        }
        public async Task<IEnumerable<User>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await (Task<IEnumerable<User>?>) _context.Users
                                 .Include(x => x.Person)
                                 .AsNoTracking();
                                 
                                 
        }
        public async Task<User?> GetByIDAsync(int ID)
        {
            if(ID <1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Users
                                 .Include(x => x.Person)
                                 .AsNoTracking()
                                 .SingleOrDefaultAsync(P => P.UserId == ID);
                                
        }

        public async Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<User> sepc)
        {
            return await sepc.Apply(_context.Users).AnyAsync();
        }
        public Task<IEnumerable<User>> FindAsync(ISepecification<User> sepecification)
        {
            throw new NotImplementedException();
        }
    }
}
