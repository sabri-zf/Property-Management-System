using Infrastructure.Entities;

namespace Infrastructure.Data.seed
{
    internal static class TenantSeedData
    {

        public static List<Tenant> Tenants = new List<Tenant>()
        {
            new Tenant(){TenantId = 1,PersonId = 4},
            new Tenant(){TenantId = 2,PersonId = 5}
        };
    }


}
