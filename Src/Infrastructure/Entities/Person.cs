using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    internal class Person
    {
        public virtual int PersonId { get; set; }

        public virtual string FirstName { get; set; } = null!;

        // not require (doesn't matter exist or not)
        public virtual string? MidName { get; set; } 
        public virtual string LastName { get; set; } = null!;
        public virtual DateOnly Birthday { get; set; }


        // not important to get the Users And Tenants as Navigation-Property to Person
        // collection of Users 
        // collextion of Tenants

        public virtual Contact Contact { get; set; }
        //public virtual ICollection<User> Users { get; set; } = new List<User>();
        //public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant  >();
    }
}
