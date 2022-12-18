using Business.Services.CoinServices;
using Business.Services.CoinServices.Dtos;
using Business.Services.UserServices;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : BaseController
    {
        private readonly ICoinService _coinService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _token;

        public CoinController(ICoinService coinService, IHttpContextAccessor httpContextAccessor)
        {
            _coinService = coinService;
            _httpContextAccessor = httpContextAccessor;
            _token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        } 

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.GetById(id,_token);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.Delete(id,_token);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdatedCoinDto updatedCoinDto)
        {
            IJsonDataResult<ResultDataJson<UpdatedCoinDto>> result = await _coinService.Update(updatedCoinDto,_token);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
