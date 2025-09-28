using Application.DTOs.UserManagementDto.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserManagementDto.MangersDto
{
    public record ClsManagerRequestDto(

        int ID,
        ClsUserResponsDto User
        );

}
