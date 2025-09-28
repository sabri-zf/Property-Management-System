namespace Application.DTOs.UserManagementDto.PeopleDto
{
    public record ClsPersonResponsDto 
        (
        string FirstName,
        string LastName,
        string? MidName,
        DateOnly BirthDay,
         DateTime CreateAt,
        DateTime? UpdateAt
        );
  
}
