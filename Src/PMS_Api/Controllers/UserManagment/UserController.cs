using Application.DTOs.UserManagementDto.UsersDto;
using Application.Services.Users;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PMS_Api.Controllers.UserManagment
{
    [ApiController]
    [Route("Api/V1/User")]
    public class UserController:Controller
    {

        private readonly ClsUsersRepository _userData;

        public UserController(ClsUsersRepository userData)
        {
            _userData = userData;
        }



        [HttpGet("/Fitech_All_User")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public async Task<ActionResult<IEnumerable<User>>> FitcheAll()
        {
            var ListOfUser = await _userData.FetchAllUsersAsync();

            if(ListOfUser is  null)
            {
                return NotFound("List Is Empty");
            }


            return Ok(ListOfUser);
        }


        [HttpPost("/Add_new")]
       
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ClsUserResponsDto>> AddNewUser(ClsUserRequestDto newUser)
        {

            if (newUser is null) return BadRequest("Invalid Data");

            var IsItHasBeenAdded = await _userData.AddNewAsync(newUser);

            if(IsItHasBeenAdded)
            {
                return Ok("Add new user Has been Successfull");
            }

            return StatusCode(StatusCodes.Status500InternalServerError,"Error ouccourred on Service");
        }


        [HttpPut("/Update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateUser(ClsUserRequestDto RequestData)
        {

            if (RequestData is null || RequestData.ID < 1) return BadRequest("Invalid Operation");

             var IsUpdated = await _userData.Update(RequestData);

            if (IsUpdated)
            {
                return Ok("User has been updated Successfully");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error uccored into Service");

        }


        [HttpDelete("/Delete_User")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult> DeleteUser(int ID)
        {
            if(ID < 1) return BadRequest("Invalid Operation");

            var IsDeleted  =  await _userData.Delete(ID);

            if(IsDeleted)
            {
                return Ok("User Has been Deleted");
            }


            return StatusCode(StatusCodes.Status500InternalServerError, "Error Ouccrred into Service");
        }
    }
}
