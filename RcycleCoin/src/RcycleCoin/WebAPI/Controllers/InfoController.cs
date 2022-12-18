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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _token;

        public InfoController(IInfoService ınfoService, IHttpContextAccessor httpContextAccessor)
        {
            _ınfoService = ınfoService;
            _httpContextAccessor = httpContextAccessor;
            _token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.GetById(id.ToString(),_token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdateInfoDto updateInfoDto,string id)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.Update(id,updateInfoDto,_token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatedInfoDto createdInfoDto)
        {
            IJsonDataResult<ResultDataJson<InfoDto>> result = await _ınfoService.Add(createdInfoDto,_token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
    }
}
