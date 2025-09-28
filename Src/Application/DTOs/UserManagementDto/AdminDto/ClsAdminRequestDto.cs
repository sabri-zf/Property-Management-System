using Application.DTOs.UserManagementDto.UsersDto;

namespace Application.DTOs.UserManagementDto.AdminDto
{
    public record ClsAdminRequestDto
   (
        int ID,
        ClsUserResponsDto User
        );
}
