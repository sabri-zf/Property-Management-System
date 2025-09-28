using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public sealed class Tenant
    {
        public  int TenantId { get; set; }
        public  int PersonId { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public  DateTime createAt { get; set; }

        [Column(TypeName = "datetime2")]
        public  DateTime? updateAt { get; set; }

        // Relationship : Tenant Represent one perosn and Person has many Tenants

        public  Person Person { get; set; }
    }
}
