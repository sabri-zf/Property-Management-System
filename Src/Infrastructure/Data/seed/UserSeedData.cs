using Domain.Entities;

namespace Infrastructure.Data.seed
{
    internal static class UserSeedData
    {

        public static List<User> Users = new List<User>()
        {

            new User(){UserId = 1 ,PersonId = 1,Username = "Admin",Password="1234",CreateAt = new DateTime(new DateOnly(2025,06,20),new TimeOnly(10,22,09)),IsActive = true},
            new User(){UserId = 2 ,PersonId = 2,Username = "@Mo_15",Password="absd",CreateAt = new DateTime(new DateOnly(2025,08,05),new TimeOnly(18,06,45)),IsActive = true},
            new User(){UserId = 3 ,PersonId = 3, Username = "@Kalif_125", Password = "Ka123", CreateAt = new DateTime(new DateOnly(2025, 08, 10), new TimeOnly(00, 22, 01)), IsActive = false}
        };
    }


}
