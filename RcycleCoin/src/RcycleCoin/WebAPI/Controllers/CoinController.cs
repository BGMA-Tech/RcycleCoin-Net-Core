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

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.GetById(id.ToString());
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            IJsonDataResult<ResultDataJson<CoinDto>> result = await _coinService.Delete(id.ToString());
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdatedCoinDto updatedCoinDto)
        {
            IJsonDataResult<ResultDataJson<UpdatedCoinDto>> result = await _coinService.Update(updatedCoinDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
