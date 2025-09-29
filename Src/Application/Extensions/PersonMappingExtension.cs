using Application.DTOs.UserManagementDto.PeopleDto;
using Application.DTOs.UserManagementDto.UsersDto;
using Application.Services;
using Domain.Entities;

namespace Application.Extensions
{
    internal static class PersonMappingExtension
    {


        public static ClsPersonResponsDto ToDto(this Person Result)
        {
            if (Result is Person)
            {
                var Person = new ClsPersonResponsDto
                (
                    Result.FirstName,
                    Result.LastName,
                    Result.MidName,
                    Result.Birthday,
                    Result.createAt,
                    Result.updateAt
                );

                return Person;
            }

            return null;
        }


        public static Person ToEntity(this ClsPersonRequestDto Result)
        {
            if (Result is ClsPersonRequestDto)
            {
                var Person = new Person
                {
                    PersonId = Result.ID,
                    FirstName = Result.FirstName,
                    LastName = Result.LastName,
                    MidName = Result.MidName,
                    Birthday = Result.BirthDay,
                    createAt = Result.CreateAt,
                    updateAt = Result.UpdateAt
                };

                return Person;
            }

            return null;
        }
    }


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
