using Domain.Entities;
using Domain.Entities.Entities_Views;
using Domin.Entities;
using Infrastructure.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContactRepo : IRepository<Contact>
    {
        readonly AppdbContext _context;

        public ContactRepo(AppdbContext context)
        {
            _context = context;
        }


        public async Task AddNewAsync(Contact entity)
        {
            if (entity is not Contact) throw new NullReferenceException("User Object doesn't Exist"); ;

            await _context.Contacts.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID < 1) throw new InvalidOperationException(" ID is not Valid"); ;

            return await _context.Contacts
                .Where(p => p.ContactId == ID)
                .ExecuteDeleteAsync() > 0;
        }
        public async Task<bool> UpdateAsync(Contact entity)
        {

            if (entity is not Contact) throw new NullReferenceException("User Object doesn't Exist");
            if (entity.ContactId < 1) throw new InvalidOperationException(" ID is not Valid");

            return await _context.Contacts
                                    .Where(x => x.ContactId == entity.ContactId)
                                    .ExecuteUpdateAsync(P => P
                                       .SetProperty(x => x.PhoneNumber, entity.PhoneNumber)
                                       .SetProperty(x => x.Email, entity.Email)
                                     ) > 0;


        }

        public async Task<IQueryable<Contact>?> GetAllAsync()
        {
            // Then Create Table View To represent The Data 
            return await (Task<IQueryable<Contact>?>) _context.Contacts
                                                              .Include(x => x.People)
                                                              .AsNoTracking();
                                 
        }

        public async Task<Contact?> GetByIDAsync(int ID)
        {
            if (ID < 1) throw new InvalidOperationException(nameof(ID) + " is not Valid");

            return await _context.Contacts
                          .SingleOrDefaultAsync(P => P.ContactId == ID);
        }

        public Task<IEnumerable<Contact>> FindAsync(ISepecification<Contact> sepecification)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<Contact> sepecification)
        {
            throw new NotImplementedException();
        }
    }
}
