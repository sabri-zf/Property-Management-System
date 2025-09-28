using Infrastructure.Data.seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.PersonId)
                .HasAnnotation("idintity","1,1");

            builder.ToTable("People");

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.LastName)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(x => x.MidName)
                  .HasMaxLength(50)
                  .IsRequired(false);

            builder.Property(x => x.Birthday)
                  .IsRequired();


            builder.HasData(PersonSeedData.people);
        }
    }
}
