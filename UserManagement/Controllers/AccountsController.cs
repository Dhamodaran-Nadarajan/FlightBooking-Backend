using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Model;
using UserManagement.Repository;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserRepository repos)
        {
            this._userRepository = repos;
        }

        #region Public Methods

        [HttpGet("login")]
        public ActionResult Get([FromQuery] string userName, [FromQuery] string pwd)
        {
            try
            {
                bool authentication = _userRepository.AuthenticateUser(userName, pwd);
                if (authentication)
                {
                    return Ok(GenerateResponseData(true, null, "Login Success !!"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, GenerateResponseData(false, null, "Invalid Username or Password !!"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }            
        }

        [HttpPost("register")]
        public ActionResult Post([FromBody] User obj)
        {
            try
            {
                bool userNameExists = _userRepository.IsUserNameExists(obj.UserName);
                if (userNameExists)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, GenerateResponseData(false, null, "Username already exists !!"));
                }
                else
                {
                    _userRepository.AddNewUser(obj);
                    //return StatusCode(StatusCodes.Status201Created);
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, GenerateResponseData(false, ex.Message, "Internal Server Error"));
            }            
        }

        #endregion

        #region Private Methods

        private object GenerateResponseData(bool isSuccess, object data, string message)
        {
            return new { isSuccess, data, message };
        }

        #endregion
    }
}
