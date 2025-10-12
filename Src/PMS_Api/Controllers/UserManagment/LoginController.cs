using Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PMS_Api.Dtos;
using System.Net;

namespace PMS_Api.Controllers.UserManagment
{
    [ApiController]
    [Route("Api/v1/auth/")]
    public class LoginController:Controller
    {

          private readonly ClsUserService _UserService;
        

        public LoginController(ClsUserService userService)
        {
            this._UserService = userService;
        }


        [Route("LogIn/{Username}/{Password}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(string Username , string Password)
        {
            //if (Use) return BadRequest("Data is not Valid");
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password)) return BadRequest("Invalid Data");

            if (await _UserService.checkInUserInfoIsValid(Username,Password))
            {
                Response.StatusCode = StatusCodes.Status200OK;
               return Content("User name Is authorized","text/plain");
            }

            Response.StatusCode = StatusCodes.Status401Unauthorized;
           return Content("you're unauthorized to login on system","text/plain");
        }


    }
}
