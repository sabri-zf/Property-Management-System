using Application.DTOs.UserManagementDto.PeopleDto;

namespace Application.DTOs.UserManagementDto.UsersDto
{
    public record ClsUserResponsDto
   (
       string FirstName,
       string LastName,
       string? MidName,
       string Username,
       string Password,
       DateOnly BirthDay,
       DateTime CreateAt,
       DateTime? UpdateAt,
       bool IsActive

   );
}
