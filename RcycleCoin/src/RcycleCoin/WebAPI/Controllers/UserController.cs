using Business.Services.UserServices;
using Business.Services.UserServices.Dtos;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _token;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromRoute]int userId)
        {
            IJsonDataResult<ResultDataJson<UserDto>> resut = await _userService.GetById(userId.ToString(),_token);
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
            if(result.Data == null)
            {
                return BadRequest(result.Data);
            }
            BaseHttpClient.Token = result.Data.Data.Token;
            return Ok(result.Data);
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
