namespace Infrastructure.Entities
{
    internal class Tenant
    {
        public virtual int TenantId { get; set; }
        public virtual int PersonId { get; set; }

        // Relationship : Tenant Represent one perosn and Person has many Tenants

        public virtual Person Person { get; set; }
    }
}
