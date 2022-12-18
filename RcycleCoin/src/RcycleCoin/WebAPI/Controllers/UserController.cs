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
            IJsonDataResult<ResultDataJson<AccessTokenDto>> result = await _userService.Login(userForLoginDto);
            if(result.Data == null)
            {
                return BadRequest(result.Data);
            }
            AccessToken accessToken = await _authService.CreateAccessToken(new User
            {
                Email= userForLoginDto.Email,
                Password= userForLoginDto.Password,
                UserId = "639e331d8f8868685db37e70",
                FirstName = "Alp",
                LastName = "Yanıkoğlu",
                Id = 1,
                PersonelId = "00e7f401eaf8cdd4a34238f4251b332370cd9fa26e4f788d90951e562a012817",
                Rol = "Personel"
            });
            BaseHttpClient.Token = result.Data.Data.Token;
            return Ok(accessToken);
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

        [HttpPost("getverifyid")]
        public async Task<IActionResult> GetVerifyId([FromBody] GetVerifyIdDto getVerifyIdDto)
        {
            IJsonDataResult<GetVerifyIdJson> result = await _userService.GetVerifyId(getVerifyIdDto);
            return Ok(result.Data);
        }
    }
}
