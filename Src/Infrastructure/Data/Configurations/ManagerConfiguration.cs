using Infrastructure.Data.seed;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.ManagerId)
                .HasAnnotation("idintity", "1,1");

            builder.ToTable(nameof(Manager) + "s");


            builder.HasOne(x => x.User)
                   .WithMany(x => x.Managers)
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();
                
            builder.HasData(ManagerSeedData.Managers);
        }
    }
}
