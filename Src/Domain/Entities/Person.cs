using Domin.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public sealed  class Person
    {
        public  int PersonId { get; set; }

        public  string FirstName { get; set; } = null!;

        // not require (doesn't matter exist or not)
        public  string? MidName { get; set; } 
        public  string LastName { get; set; } = null!;
        public  DateOnly Birthday { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public  DateTime createAt { get; set; }

        [Column(TypeName = "datetime2")]
        public  DateTime? updateAt { get; set; }


        // not important to get the Users And Tenants as Navigation-Property to Person
        // collection of Users 
        // collextion of Tenants

        public  Contact Contact { get; set; }
        //public virtual ICollection<User> Users { get; set; } = new List<User>();
        //public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant  >();
    }
}
