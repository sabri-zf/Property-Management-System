using Application.DTOs.UserManagementDto.PeopleDto;

namespace Application.DTOs.UserManagementDto.ContactsDto
{
    public record ClsContactResponsDto
   (
       ClsPersonResponsDto Person,
       string PhoneNumber,
       string Email
        );

}
