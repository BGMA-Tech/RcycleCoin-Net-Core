using Business.Services.RecycleProductImageService;
using Business.Services.RecycleProductImageService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleProductImageController : BaseController
    {
        private readonly IRecycleProductImageService _recycleProductImageService;

        public RecycleProductImageController(IRecycleProductImageService recycleProductImageService)
        {
            _recycleProductImageService = recycleProductImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file)
        {
            var result = _recycleProductImageService.Add(file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int id)
        {
            var result = _recycleProductImageService.GetByImageId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _recycleProductImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
