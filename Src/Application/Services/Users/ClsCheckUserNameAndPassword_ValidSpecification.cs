using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Users
{
    public class ClsCheckUserNameAndPassword_ValidSpecification : ISepecification<User>
    {

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public ClsCheckUserNameAndPassword_ValidSpecification(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        
        public IQueryable<User> Apply(IQueryable<User> query)
        {
          return query.Where(x => x.Username == this.Username && x.Password == this.Password);
        }

    }
}
