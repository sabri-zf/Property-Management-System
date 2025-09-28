using Infrastructure.Data;
using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class UserRepo : IRepository<User>
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
                                 .ExecuteUpdateAsync(P => P
                                    .SetProperty(x =>  x.Username, entity.Username)
                                    .SetProperty(x => x.Password, entity.Password)
                                    .SetProperty(x => x.UpdateAt, entity.UpdateAt)
                                    .SetProperty(x => x.IsActive, entity.IsActive)
                                  ) > 0;  
                                 
                                 
        }
        public async Task<List<UserView>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await _context.UserViews
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task<User?> GetByIDAsync(int ID)
        {
            if(ID <1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Users
                          .SingleOrDefaultAsync(P => P.UserId == ID);
        }

      
    }
}
