using Business.Services.AuthServices;
using Business.Services.UserServices;
using Business.Services.UserServices.Dtos;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string userId)
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
            IJsonDataResult<ResultDataJson<AccessToken>> result = await _userService.Login(userForLoginDto);
            if(result.Data.Data.Token == null)
            {
                return BadRequest(result.Data.Data);
            }
            return Ok(result.Data.Data);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            IJsonDataResult<ResultDataJson<UserDto>> result = await _userService.Register(userForRegisterDto);
            if (result.Data != null)
            {
                return Ok(result.Data.Data);
            }
            return BadRequest(result.Data.Data);
        }

        [HttpPost("getverifyid")]
        public async Task<IActionResult> GetVerifyId([FromBody] GetVerifyIdDto getVerifyIdDto)
        {
            IJsonDataResult<GetVerifyIdJson> result = await _userService.GetVerifyId(getVerifyIdDto);
            return Ok(result.Data);
        }
    }
}
