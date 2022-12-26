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

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatedTransactionDto createdTransactionDto)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> result = await _transactionService.Add(createdTransactionDto);
            if (result != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> result = await _transactionService.GetById(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAll();
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getallbyid")]
        public async Task<IActionResult> GetAllById(string id)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllById(id);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getallbytopersonelid")]
        public async Task<IActionResult> GetAllByToPersonelId(string toPersonelId)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllByToPersonelId(toPersonelId);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getallbyfrompersonelid")]
        public async Task<IActionResult> GetAllByFromPersonelId(string fromPersonelId)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllByFromPersonelId(fromPersonelId);
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Data);
        }
    }
}
