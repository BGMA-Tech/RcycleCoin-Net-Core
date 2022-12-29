using Business.Services.CoinServices;
using Business.Services.CoinServices.Dtos;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : BaseController
    {
        private readonly ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        } 

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.GetById(id);
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

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.Delete(id);
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatedCoinDto updatedCoinDto,string id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.Update(id,updatedCoinDto);
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
    }
}
