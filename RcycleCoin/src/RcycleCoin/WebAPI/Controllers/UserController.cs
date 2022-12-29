using Business.Services.AuthServices;
using Business.Services.TransactionServices.Dtos;
using Business.Services.TransactionServices;
using Business.Services.UserServices;
using Business.Services.UserServices.Dtos;
using Core.Helper;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Core.Utilities.Security.Jwt;
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
        public async Task<IActionResult> GetById(string userId)
        {
            IJsonDataResult<ResultDataJson<UserDto>> result = await _userService.GetById(userId.ToString());
            if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            else if (result.Data != null && result.Data.Data != null)
            {
                return Ok(result.Data);
            }
            return NotFound(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            IJsonDataResult<ResultDataJson<AccessToken>> result = await _userService.Login(userForLoginDto);
            if (result.Data != null && result.Data.Data == null)
            {
                return BadRequest(result.Data);
            }
            return Ok(result.Data.Data);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            IJsonDataResult<ResultDataJson<UserDto>> result = await _userService.Register(userForRegisterDto);
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Mail exists")
            {
                return Conflict(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPost("getverifyid")]
        public async Task<IActionResult> GetVerifyId([FromBody] GetVerifyIdDto getVerifyIdDto)
        {
            IJsonDataResult<GetVerifyIdJson> result = await _userService.GetVerifyId(getVerifyIdDto);
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IJsonDataResult<ResultDataJson<List<UserDto>>> result = await _userService.GetAll();
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            return BadRequest(result.Data);
        }
    }
}
