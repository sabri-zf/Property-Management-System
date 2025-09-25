using Infrastructure.Data.seed;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(x => x.TenantId)
                .HasAnnotation("idintity", "1,1");

            builder.ToTable(nameof(Tenant) + "s");

            builder.HasOne(x => x.Person)
                   .WithMany()
                   .HasForeignKey(x => x.PersonId)
                   .IsRequired();

            builder.HasData(TenantSeedData.Tenants);
        }
    }
}
