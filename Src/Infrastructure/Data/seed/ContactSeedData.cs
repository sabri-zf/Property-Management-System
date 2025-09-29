using Domin.Entities;

namespace Infrastructure.Data.seed
{
    internal static class ContactSeedData
    {
        // Phone Number  : 10 digits

        public static List<Contact> Contacts = new List<Contact>()
        {
            new Contact(){ ContactId = 1,PerosnID = 1 , PhoneNumber = "0659861234" ,Email ="Sabri@gmail.com"},
            new Contact(){ ContactId = 2,PerosnID = 1 , PhoneNumber = "0667234678" ,Email ="Sabri22@gmail.com"},
            new Contact(){ ContactId = 3,PerosnID = 2 , PhoneNumber = "0577539612" ,Email ="Mohamed12@yahoo.com"},
            new Contact(){ ContactId = 4,PerosnID = 3 , PhoneNumber = "0577134689" ,Email ="Khalifa225@yahoo.com"},
            new Contact(){ ContactId = 5,PerosnID = 4 , PhoneNumber = "0577530100" ,Email ="BenSalim45@yahoo.com"},
            new Contact(){ ContactId = 6,PerosnID = 5 , PhoneNumber = "0577339812" ,Email ="Salma@gmial.com"},
        };
    }

}
