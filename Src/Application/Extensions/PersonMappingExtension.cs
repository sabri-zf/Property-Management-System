using Application.DTOs.UserManagementDto.PeopleDto;
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
}
