using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DTO;
using UserManagement.Model;
using UserManagement.Repository;
using UserManagement.Services.Interfaces;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region Private Fields & Constructor

        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;        

        public AccountsController(IUserRepository repos, ITokenService tokenService)
        {
            this._userRepository = repos;
            this._tokenService = tokenService;
        }
        #endregion

        #region Public Methods

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepository.GetUser(loginDto.Username);
                if (user == null) return BadRequest("Invalid username !!");

                using (var hmac = new HMACSHA512(user.PasswordSalt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                    for(int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != user.PasswordHash[i])
                            return StatusCode(StatusCodes.Status401Unauthorized,$"Incorrect 'Username' or 'Password' !!");
                    }
                    return new UserDto
                    {
                        Username = user.UserName,
                        Token = _tokenService.GenerateToken(user)
                    };
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDto registerUserDto)
        {
            try
            {
                if (await _userRepository.IsUserNameExists(registerUserDto.Username)) return BadRequest("Username already exists !!");
                using (var hmac = new HMACSHA512())
                {
                    var user = new User
                    {
                        UserName = registerUserDto.Username,
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password)),
                        PasswordSalt = hmac.Key,
                        Email = registerUserDto.Email,
                        Gender = registerUserDto.Gender,
                        ContactNumber = registerUserDto.ContactNumber
                    };
                    await _userRepository.AddNewUser(user);
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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

        #region Old Code
        /*[HttpGet("login")]
        public ActionResult Get([FromQuery] string userName, [FromQuery] string pwd)
        {
            try
            {
                //bool authentication = _userRepository.AuthenticateUser(userName, pwd);
                bool authentication = true;
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
        }*/
        #endregion
    }
}
