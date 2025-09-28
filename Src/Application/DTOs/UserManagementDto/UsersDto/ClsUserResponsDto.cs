using Application.DTOs.UserManagementDto.PeopleDto;

namespace Application.DTOs.UserManagementDto.UsersDto
{
    public record ClsUserResponsDto
   (
       ClsPersonResponsDto Person,
       string Username,
       string Password,
       DateTime CreateAt,
       DateTime? UpdateAt,
       bool IsActive

   );
}
