using Infrastructure.Data;
using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class PeopleRepo :IRepository<Person>
    {


        readonly AppdbContext _context;

        public PeopleRepo(AppdbContext context)
        {
            _context = context;
        }

        public async Task AddNewAsync(Person entity)
        {
            if (entity is not Person) throw new NullReferenceException("User Object doesn't Exist"); ;

            await _context.Set<Person>().AddAsync(entity);

        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1) throw new InvalidOperationException(" ID is not Valid"); ;

            return await _context.Set<Person>()
                .Where(p => p.PersonId == ID)
                .ExecuteDeleteAsync()>0;
        }
        public async Task<bool> UpdateAsync(Person entity)
        {

            if (entity is not Person) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.PersonId < 1) throw new (" ID is not Valid");

            return await _context.Set<Person>()
                                    .Where(x => x.PersonId == entity.PersonId)
                                    .ExecuteUpdateAsync(P => P
                                       .SetProperty(x => x.FirstName, entity.FirstName)
                                       .SetProperty(x => x.LastName, entity.LastName)
                                       .SetProperty(x => x.MidName, entity.MidName)
                                       .SetProperty(x => x.Birthday, entity.Birthday)
                                     ) > 0;
        }

        public  async Task<IQueryable<Person>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await (Task<IQueryable<Person>?>)_context.Set<Person>()
                                                          .AsNoTracking();
        }

        public async Task<Person?> GetByIDAsync(int ID)
        {
            if (ID < 1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Set<Person>()
                          .SingleOrDefaultAsync(P => P.PersonId == ID);
        }

        public Task<IEnumerable<Person>> FindAsync(ISepecification<Person> sepecification)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<Person> sepecification)
        {
            throw new NotImplementedException();
        }
    }
}
