using Business.Services.InfoServices;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
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
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.GetById(id.ToString());
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInfoDto updateInfoDto,string id)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.Update(id,updateInfoDto);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatedInfoDto createdInfoDto)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.Add(createdInfoDto);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
    }
}
