using Application.DTOs.UserManagementDto.PeopleDto;
using Application.DTOs.UserManagementDto.UsersDto;
using Domain.Interfaces;
using Domain.Entities;
using Application.Extensions;

namespace Application.Services
{
   public abstract class ClsPeople
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public DateOnly BirthDay { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        private readonly IRepository<Person> _PeopleRepo;

        protected ClsPeople(ClsPersonRequestDto PersonDto,IRepository<Person> peopleRepo)
        {
            this.ID = PersonDto.ID;
            this.FirstName = PersonDto.FirstName;
            this.LastName = PersonDto.LastName;
            this.MidName = PersonDto.MidName;
            this.BirthDay = PersonDto.BirthDay;
            this.CreateAt = PersonDto.CreateAt;
            this.UpdateAt = PersonDto?.UpdateAt;
            this._PeopleRepo = peopleRepo;
        }

        protected ClsPeople(ClsPersonRequestDto PersonDto)
        {
            this.ID = PersonDto.ID;
            this.FirstName = PersonDto.FirstName;
            this.LastName = PersonDto.LastName;
            this.MidName = PersonDto.MidName;
            this.BirthDay = PersonDto.BirthDay;
            this.CreateAt = PersonDto.CreateAt;
            this.UpdateAt = PersonDto?.UpdateAt;
        }



        public async Task<ClsPersonResponsDto?> FindByID(int ID)
        {
            try
            {
               var Result = await _PeopleRepo.GetByIDAsync(ID);

                if (Result != null)
                {

                    return  Result.ToDto();
                    
                }
            }
            catch (Exception ex)
            {
                // Loggin the Exeption of Server 
            }


            return null;
        }

        public virtual Task<bool> AddNew()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Update()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

    }


    public class ClsUsers:ClsPeople, IDataService<ClsUsers>
    {
        public int UserID { get; set; }
        public ClsPeople Perosn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }

         




        public ClsUsers(ClsUserRequestDto UserDto):
            base(UserDto.Person)
        {
            this.UserID = UserDto.ID;
            this.Username = UserDto.Username;
            this.Password = UserDto.Password;
            this.Perosn = ;


        }
        public Task<bool> AddNew()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<ClsUsers> FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update()
        {
            throw new NotImplementedException();
        }


        //public ClsUsers(ClsPersonRequestDto PersonDto, PeopleRepo peopleRepo) : base(PersonDto, peopleRepo)
        //{
        //}



    }
}
