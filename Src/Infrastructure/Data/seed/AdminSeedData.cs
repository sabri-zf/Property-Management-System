using Infrastructure.Entities;

namespace Infrastructure.Data.seed
{
    internal static class AdminSeedData
    {

        public static List<Admin> Admins = new List<Admin>()
        {
            new Admin(){ AdminId = 1 ,UserId= 1}
        };
    }


}
