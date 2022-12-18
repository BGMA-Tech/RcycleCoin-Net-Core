using Business.Services.TransactionServices;
using Business.Services.TransactionServices.Dtos;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _token;

        public TransactionController(ITransactionService transactionService, IHttpContextAccessor httpContextAccessor)
        {
            _transactionService = transactionService;
            _httpContextAccessor = httpContextAccessor;
            _token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        [HttpPost("add")]
        public async Task<IActionResult> GetById([FromBody] CreatedTransactionDto createdTransactionDto)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> result = await _transactionService.Add(createdTransactionDto,_token);
            if (result != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> result = await _transactionService.GetById(id,_token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAll(_token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getallbyid")]
        public async Task<IActionResult> GetAllById(string id)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllById(id, _token);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
    }
}
