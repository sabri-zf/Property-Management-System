using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Entities
{
    [Table("Contacts")]
    public sealed class Contact
    {

        [Column(Order = 0)]
        [Key]
        public  int ContactId { get; set; }

        [Column(Order =2)]
        [Required]
        [StringLength(maximumLength:10,MinimumLength =10)]
        public  string PhoneNumber { get; set; } = null!;

        [Column(Order = 3)]
        [Required]
        [EmailAddress]
        public  string Email { get; set; } = null!;
       
        [Column(Order = 1)]
        [Required]
        public  int PerosnID { get; set; }

        // Relationship : any Person can have many Contacts
        public  ICollection<Person> People { get; set; } = new List<Person>();
    }
}
