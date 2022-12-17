using Business.Services.CoinServices.Dtos;
using Business.Services.CoinServices;
using Business.Services.InfoServices;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Services.InfoServices.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : BaseController
    {
        private readonly IInfoService _ınfoService;

        public InfoController(IInfoService ınfoService)
        {
            _ınfoService = ınfoService;
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.GetById(id.ToString());
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInfoDto updateInfoDto)
        {
            IJsonDataResult<ResultDataJson<UpdateInfoDto>> result = await _ınfoService.Update(updateInfoDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatedInfoDto createdInfoDto)
        {
            IJsonDataResult<ResultDataJson<CreatedInfoDto>> result = await _ınfoService.Add(createdInfoDto);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
