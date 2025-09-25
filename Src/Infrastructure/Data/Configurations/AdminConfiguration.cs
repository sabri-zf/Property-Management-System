using Infrastructure.Data.seed;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.AdminId)
                .HasAnnotation("idintity", "1,1");

            builder.ToTable(nameof(Admin) + "s");


            builder.HasOne(x => x.User)
                   .WithOne(x => x.Admin)
                   .HasForeignKey<Admin>(x => x.UserId)
                   .IsRequired();

            builder.HasData(AdminSeedData.Admins);
        }
    }
}
