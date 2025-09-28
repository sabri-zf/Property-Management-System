using Domain.Entities;
using Infrastructure.Data.seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId)
                .HasAnnotation("idintity", "1,1");
                

            builder.ToTable(nameof(User)+"s");

            builder.Property(x => x.UserId)
                  .IsRequired()
                  .HasColumnOrder(0);

            builder.Property(x => x.PersonId)
                 .IsRequired()
                 .HasColumnOrder(1);

            builder.Property(x => x.Username)
                   .HasMaxLength(10)
                   .IsRequired()
                   .HasColumnOrder(2);

            builder.Property(x => x.Password)
                  .HasMaxLength(9)
                  .IsRequired()
                  .HasColumnOrder(3);

            builder.Property(x => x.CreateAt)
                  .IsRequired()
                  .HasColumnOrder(4);

            builder.Property(x => x.UpdateAt)
                 .IsRequired(false)
                 .HasColumnOrder(5);


            builder.Property(x => x.IsActive)
                 .IsRequired()
                 .HasColumnOrder(6);

            builder.HasOne(x => x.Person)
                   .WithMany()
                   .HasForeignKey(x => x.PersonId)
                   .IsRequired();

            builder.HasData(UserSeedData.Users);
        }
    }
}
