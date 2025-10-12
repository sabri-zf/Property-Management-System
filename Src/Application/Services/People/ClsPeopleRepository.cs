using Application.DTOs.UserManagementDto.PeopleDto;
using Domain.Interfaces;
using Domain.Entities;
using Application.Extensions;

namespace Application.Services.People
{
    public  class ClsPeopleRepository
    {

        private readonly IRepository<Person> _PeopleRepo;
        private readonly IUnitOfWork _UnitOfWork;

        public ClsPeopleRepository(IRepository<Person> peopleRepo, IUnitOfWork unitOfWork)
        {
            _PeopleRepo = peopleRepo;
            _UnitOfWork = unitOfWork;
        }

        public async Task<ClsPersonResponsDto?> FindByIDAsync(int ID)
        {

            if (ID < 1) return null;

            try
            {
                var Result = await _PeopleRepo.GetByIDAsync(ID);

                if (Result != null)
                {

                    return Result.ToDto();

                }
            }
            catch (InvalidOperationException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }


            return null;
        }

        public async Task<bool> AddNewAsync(ClsPersonRequestDto PersonRequest)
        {
            if (PersonRequest == null) return false;

            try
            {
                Person person = PersonRequest.ToEntity();

                await _PeopleRepo.AddNewAsync(person);

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

        public async Task<bool> UpdateAsync(ClsPersonRequestDto PersonRequest)
        {

            if (PersonRequest == null || PersonRequest.ID < 1) return false;

            try
            {
                Person person = PersonRequest.ToEntity();

                return await _PeopleRepo.UpdateAsync(person);

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

        public async Task<bool> DeleteAsync(int ID)
        {
            if (ID < 1) return false;

            try
            {
                return await _PeopleRepo.DeleteAsync(ID);
            }
            catch (InvalidOperationException ex)
            {
                // Loggin the Exeption of Server 
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }

            return false;
        }

        public async Task<IEnumerable<Person>?> FetchAllPeopleAsync()
        {
            try
            {
                return await _PeopleRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
            }

            return null;
        }

    }
}
