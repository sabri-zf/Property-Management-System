using Domain.Interfaces;

namespace Application.Services.Users
{
    public class ClsUserService
    {
        private readonly IUserServers _userServers;

        public ClsUserService(IUserServers userServers)
        {
            _userServers = userServers;
        }


        public async Task<bool> checkInUserInfoIsValid(string username, string password)
        {

            var spec = new ClsCheckUserNameAndPassword_ValidSpecification(username, password);

            if (await _userServers.IsValid_UserNameAndPasswordAsync(spec))
            {
                return true;
            }


            return false;
        }
    }
}
