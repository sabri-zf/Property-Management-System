using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Contacts")]
    internal class Contact
    {

        [Column(Order = 0)]
        [Key]
        public virtual int ContactId { get; set; }

        [Column(Order =2)]
        [Required]
        [StringLength(maximumLength:10,MinimumLength =10)]
        public virtual string PhoneNumber { get; set; } = null!;

        [Column(Order = 3)]
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; } = null!;
       
        [Column(Order = 1)]
        [Required]
        public virtual int PerosnID { get; set; }

        // Relationship : any Person can have many Contacts
        public virtual ICollection<Person> People { get; set; } = new List<Person>();
    }
}
