using Domain.Entities;

namespace Infrastructure.Data.seed
{
    internal static class PersonSeedData
    {

        public static List<Person> people = new List<Person>()
        {
            new Person(){PersonId = 1,FirstName = "Sabri" , LastName = "Zekkour Ferhat",Birthday= new DateOnly(2001,08,27),createAt = new DateTime(2025,08,12,11,30,30)},
            new Person(){PersonId = 2,FirstName = "Mohammed" , LastName = "Ali",Birthday= new DateOnly(2002,01,10),createAt = new DateTime(2025,08,12,11,30,30)},
            new Person(){PersonId = 3,FirstName = "Khalifa" , LastName = "Abu-Salah",Birthday= new DateOnly(1985,11,22), createAt = new DateTime(2025, 08, 12, 11, 30, 30)},
            new Person(){PersonId = 4,FirstName = "BenSalim" , LastName = "Sahraoui",Birthday= new DateOnly(1970,03,15), createAt = new DateTime(2025, 08, 12, 11, 30, 30)},
            new Person(){PersonId = 5,FirstName = "Salma" , LastName = "Tdjany",Birthday= new DateOnly(1993,06,01), createAt = new DateTime(2025, 08, 12, 11, 30, 30)},
        };
    }

}
