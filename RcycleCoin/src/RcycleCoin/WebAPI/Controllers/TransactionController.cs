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
            if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            else if (result.Data != null && result.Data.Data != null)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            IJsonDataResult<ResultDataJson<TransactionDto>> result = await _transactionService.GetById(id);
            if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            else if (result.Data != null && result.Data.Data != null)
            {
                return Ok(result.Data.Data);
            }
            return NotFound(result.Data);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAll();
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            return BadRequest(result.Data);
        }

        [HttpGet("getallbyid")]
        public async Task<IActionResult> GetAllById(string id)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllById(id);
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            return NotFound(result.Data);
        }

        [HttpGet("getallbytopersonelid")]
        public async Task<IActionResult> GetAllByToPersonelId(string toPersonelId)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllByToPersonelId(toPersonelId);
            if (result.Data.Status)
            {
                return Ok(result.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            return NotFound(result.Data);
        }

        [HttpGet("getallbyfrompersonelid")]
        public async Task<IActionResult> GetAllByFromPersonelId(string fromPersonelId)
        {
            IJsonDataResult<ResultDataJson<List<TransactionDto>>> result = await _transactionService.GetAllByFromPersonelId(fromPersonelId);
            if (result.Data.Status)
            {
                return Ok(result.Data.Data);
            }
            else if (result.Data.ErrorMessage != null && result.Data.ErrorMessage.Message == "Auth Failed")
            {
                return Unauthorized(result.Data);
            }
            return NotFound(result.Data);
        }
    }
}
