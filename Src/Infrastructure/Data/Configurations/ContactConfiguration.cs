using Domin.Entities;
using Infrastructure.Data.seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            
            builder.HasMany(x => x.People)
                   .WithOne(x => x.Contact)
                   .HasForeignKey(x => x.PersonId)
                   .IsRequired();

            builder.HasData(ContactSeedData.Contacts);
        }
    }
}
