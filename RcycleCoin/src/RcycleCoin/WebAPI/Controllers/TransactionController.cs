using Business.Services.TransactionServices;
using Business.Services.TransactionServices.Dtos;
using Business.Services.UserServices.Dtos;
using Core.Utilities.Abstract;
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

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> GetById([FromBody] CreatedTransactionDto createdTransactionDto)
        {
            IJsonDataResult<ResultDataJson<CreatedTransactionDto>> resut = await _transactionService.Add(createdTransactionDto);
            if (resut != null)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> resut = await _transactionService.GetById(id.ToString());
            if (resut.Data != null)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> resut = await _transactionService.GetAll();
            if (resut.Data != null)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }

        [HttpGet("getallbyid")]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> resut = await _transactionService.GetAllById(id.ToString());
            if (resut.Data != null)
            {
                return Ok(resut);
            }
            return BadRequest("Hatalı işlem");
        }
    }
}
