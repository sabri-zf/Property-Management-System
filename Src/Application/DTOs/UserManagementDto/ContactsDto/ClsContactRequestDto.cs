using Application.DTOs.UserManagementDto.PeopleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserManagementDto.ContactsDto
{
    public record ClsContactRequestDto
    (
        int ID,
        ClsPersonResponsDto Person,
        string PhoneNumber,
        string Email
        
    );

}
