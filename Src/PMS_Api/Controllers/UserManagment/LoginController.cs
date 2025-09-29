using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PMS_Api.Dtos;
using System.Net;

namespace PMS_Api.Controllers.UserManagment
{
    [ApiController]
    [Route("Api/v1/[Controller]")]
    public class LoginController:ControllerBase
    {

          private readonly ClsUsers _UserData;
        

        public LoginController(ClsUsers userData)
        {
            this._UserData = userData;
        }


        [Route("Login")]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode:StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode:StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(UserLogIn UserDto)
        {
            if (UserDto == null) return BadRequest("Data is not Valid");
            if (string.IsNullOrEmpty(UserDto.Username)) return BadRequest("Invalid Data");
            if (string.IsNullOrEmpty(UserDto.Password)) return BadRequest("Invalid Data");

            if (await _UserData.checkInUserInfoIsValid(UserDto.Username, UserDto.Password))
            {
                Response.StatusCode = 200;
                await Response.WriteAsync("User name Is Authonticate");
                return Ok();
            }


            Response.StatusCode = 404;

             await Response.WriteAsync("you're not valid to login on system");

            return NotFound();

        }


    }
}
