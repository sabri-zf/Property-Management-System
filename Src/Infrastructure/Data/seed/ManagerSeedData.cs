using Infrastructure.Entities;

namespace Infrastructure.Data.seed
{
    internal static class ManagerSeedData
    {

        public static List<Manager> Managers = new List<Manager>()
        {
            new Manager(){ManagerId= 1,UserId = 2},
            new Manager(){ManagerId= 2,UserId = 3}

        };
    }


}
