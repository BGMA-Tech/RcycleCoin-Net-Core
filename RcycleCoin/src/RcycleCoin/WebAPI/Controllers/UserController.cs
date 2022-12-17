using Business.Services.UserServices;
using Business.Services.UserServices.Dtos;
using Core.Security.JWT;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromRoute]int userId)
        {
            IJsonDataResult<ResultDataJson<UserDto>> resut = await _userService.GetById(userId.ToString());
            if(resut.Data != null)
            {
                return Ok(resut);
            }
            return BadRequest(resut);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            IJsonDataResult<ResultDataJson<AccessTokenDto>> result = await _userService.Login(userForLoginDto);
            if(result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            IJsonDataResult<ResultDataJson<AccessTokenDto>> result = await _userService.Register(userForRegisterDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
