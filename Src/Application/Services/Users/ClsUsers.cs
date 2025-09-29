using Application.DTOs.UserManagementDto.UsersDto;
using Domain.Interfaces;
using Domain.Entities;
using Application.Extensions;

namespace Application.Services.Users
{
    public class ClsUsers
    {
        private readonly IRepository<User> _UserRepo;
        private readonly IUnitOfWork _UnitOfWork;


        public ClsUsers(IRepository<User> peopleRepo, IUnitOfWork unitOfWork)
        {
            _UserRepo = peopleRepo;
            _UnitOfWork = unitOfWork;
        }

        public async Task<bool> AddNewAsync(ClsUserRequestDto userRequest)
        {

            if (userRequest == null) return false;
            try
            {
                User User = userRequest.ToEntity();

                await _UserRepo.AddNewAsync(User);

                return await _UnitOfWork.SaveAsync() > 0;

            }
            catch (NullReferenceException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }

            return false;
        }

        public async Task<bool> Delete(int ID)
        {
            if (ID < 1) return false;

            try
            {
                return await _UserRepo.DeleteAsync(ID);
            }
            catch (InvalidOperationException ex)
            {

            }
            catch (Exception ex)
            {
            }

            return false;
        }

        public async Task<ClsUserResponsDto?> FindByIDAsync(int ID)
        {
            if (ID < 1) return null;

            try
            {

                var Result = await _UserRepo.GetByIDAsync(ID);

                if (Result is not null)
                {
                    return Result?.ToDto();
                }

            }
            catch (NullReferenceException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }

            return null;
        }

        public async Task<bool> Update(ClsUserRequestDto UserRequest)
        {
            if (UserRequest == null || UserRequest.ID < 1) return false;

            try
            {
                User user = UserRequest.ToEntity();

                return await _UserRepo.UpdateAsync(user);

            }
            catch (InvalidOperationException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (NullReferenceException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }

            return false;
        }

        public async Task<IQueryable<User>?> FetchAllPeopleAsync()
        {
            try
            {
                return await _UserRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        public async Task<bool> checkInUserInfoIsValid(string username, string password)
        {

            var spec = new ClsCheckUserNameAndPassword_ValidSpecification(username, password);

            if ( await _UserRepo.IsValid_UserNameAndPasswordAsync(spec))
            {
                return true;
            }


            return false;
        }
    }
}
