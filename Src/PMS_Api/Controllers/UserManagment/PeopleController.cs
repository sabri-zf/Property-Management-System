using Application.DTOs.UserManagementDto.PeopleDto;
using Application.DTOs.UserManagementDto.UsersDto;
using Application.Services.People;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PMS_Api.Controllers.UserManagment
{
    [ApiController]

    [Route("Api/V1/People")]
    public class PeopleController : Controller
    {

        private readonly ClsPeopleRepository _peopleData;

        public PeopleController(ClsPeopleRepository data) 
        {
            _peopleData = data;
        }

        [HttpGet("FitchAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async Task<ActionResult<Person>> GetAllPeople()
        {
            var List_Of_People = await _peopleData.FetchAllPeopleAsync();

            if (List_Of_People == null || List_Of_People.Count() < 1)
            {
                return NotFound("Data not Found");
            }

            return Ok(List_Of_People);
        }

        [HttpPost("AddPerson")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< ActionResult<ClsPersonResponsDto>> AddNewPerosn(ClsPersonRequestDto requestDto)
        {
            if (requestDto == null) return BadRequest("Data is not Valid");
            var IsAdded = await _peopleData.AddNewAsync(requestDto);

            if (IsAdded)
            {
            ClsPersonResponsDto person = new ClsPersonResponsDto
            (
               requestDto.FirstName,
               requestDto.LastName,
               requestDto.MidName,
               requestDto.BirthDay,
               requestDto.CreateAt,
               requestDto.UpdateAt
            );

                return CreatedAtAction(nameof(AddNewPerosn), person);

            }           


            return StatusCode(StatusCodes.Status500InternalServerError,null);
        }


        [HttpPut("/Update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ClsPersonResponsDto>> UpdatePerson(ClsPersonRequestDto RequestData)
        {
            if (RequestData is null ||Is_ID_GreatThan_One(RequestData.ID)) return BadRequest("Invalid Operation ");

            var Resutn_Person_Obj = await _peopleData.FindByIDAsync(RequestData.ID);

            if (Resutn_Person_Obj is null)
            {
                return NotFound("User Not Found");
            }
            else
            
            return Ok(Resutn_Person_Obj);
        }


        [HttpDelete("Delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePerson(int ID)
        {
            if (!Is_ID_GreatThan_One(ID)) BadRequest("Invalid Operation");

            var Is_It_Have_Been_Deleted = await _peopleData.DeleteAsync(ID);

            if(Is_It_Have_Been_Deleted)
            {
                return Ok("Person Has been Deleted successfully");
            }
            
            return StatusCode(StatusCodes.Status500InternalServerError, null);
        }



        public bool Is_ID_GreatThan_One(int ID)
        {
            return ID > 1;
        }

    }
}
