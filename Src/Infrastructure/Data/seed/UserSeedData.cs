using Domain.Entities;

namespace Infrastructure.Data.seed
{
    internal static class UserSeedData
    {

        public static List<User> Users = new List<User>()
        {

            new User(){UserId = 1 ,PersonId = 1,Username = "Admin",Password="1234" ,IsActive = true},
            new User(){UserId = 2 ,PersonId = 2,Username = "@Mo_15",Password="absd",IsActive = true},
            new User(){UserId = 3 ,PersonId = 3, Username = "@Kalif_125", Password = "Ka123" , IsActive = false}
        };
    }


}
