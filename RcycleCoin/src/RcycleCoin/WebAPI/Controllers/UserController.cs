using Business.Services.UserServices;
using Business.Services.UserServices.Dtos;
using Core.Security.JWT;
using Core.Utilities.Abstract;
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
            var resut = await _userService.GetById(userId.ToString());
            return Ok(resut);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            IDataResult<AccessToken> result = await _userService.Login(userForLoginDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            IDataResult<AccessToken> result = await _userService.Register(userForRegisterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("Hatalı işlem");
        }
    }
}
