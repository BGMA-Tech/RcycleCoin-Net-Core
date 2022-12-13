using Business.Services.CoinServices;
using Business.Services.CoinServices.Dtos;
using Business.Services.UserServices;
using Core.Utilities.Abstract;
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
            IDataResult<ResultDataJson<CoinDto>> resut = await _coinService.GetById(id.ToString());
            if (resut.Success)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            IDataResult<ResultDataJson<CoinDto>> resut = await _coinService.Delete(id.ToString());
            if (resut.Success)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdatedCoinDto updatedCoinDto)
        {
            IDataResult<ResultDataJson<UpdatedCoinDto>> resut = await _coinService.Update(updatedCoinDto);
            if (resut.Success)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }
    }
}
