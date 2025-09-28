using Application.DTOs.UserManagementDto.PeopleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserManagementDto.TenantsDto
{
    public record ClsTenantRequestDto
   (
        int ID,
        ClsPersonResponsDto person
        );
}
