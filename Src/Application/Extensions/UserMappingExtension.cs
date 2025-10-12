using Application.DTOs.UserManagementDto.UsersDto;
using Domain.Entities;

namespace Application.Extensions
{
    internal static class UserMappingExtension
    {


        public static ClsUserResponsDto? ToDto(this User Result)
        {
            if (Result is User)
            {
                var User = new ClsUserResponsDto
                (
                   Result.Person.FirstName,
                   Result.Person.LastName,
                   Result.Person.MidName,
                   Result.Username,
                   Result.Password,
                   Result.Person.Birthday,
                   Result.Person.createAt,
                   Result.Person.updateAt,
                   Result.IsActive
                );

                return User;
            }

            return null;
        }


        public static User ToEntity(this ClsUserRequestDto Result)
        {
            if (Result is ClsUserRequestDto)
            {
                var User = new User
                {
                    UserId = Result.ID,
                    PersonId = Result.personID,
                    Username = Result.Username,
                    Password = Result.Password,
                    IsActive = Result.IsActive
                };

                return User;
            }

            return null;
        }
    }
}
