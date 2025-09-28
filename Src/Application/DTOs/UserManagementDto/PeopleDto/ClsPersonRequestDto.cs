using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserManagementDto.PeopleDto
{
    public record ClsPersonRequestDto (

        int ID,
        string FirstName,
        string LastName,
        string MidName,
        DateOnly BirthDay,
        DateTime CreateAt,
        DateTime? UpdateAt
        );
    
}
