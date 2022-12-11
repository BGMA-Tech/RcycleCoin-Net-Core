using Business.Features.RecycleTypes.Models;
using Business.Features.RecycleTypes.Queries.GetListRecycleTypeByDynamic;
using Business.Features.RecycleTypes.Commands.CreateRecycleType;
using Business.Features.RecycleTypes.Commands.DeleteRecycleType;
using Business.Features.RecycleTypes.Commands.UpdateRecycleType;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Queries.GetByIdRecycleType;
using Business.Features.RecycleTypes.Queries.GetListRecycleType;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleTypeController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateRecycleTypeCommand createRecycleTypeCommand)
        {
            CreatedRecycleTypeDto result = await Mediator.Send(createRecycleTypeCommand);
            return Created("", result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRecycleTypeCommand deletedRecycleTypeCommand)
        {
            DeletedRecycleTypeDto result = await Mediator.Send(deletedRecycleTypeCommand);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRecycleTypeCommand updatedRecycleTypeCommand)
        {
            UpdatedRecycleTypeDto result = await Mediator.Send(updatedRecycleTypeCommand);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListRecycleTypeQuery getListRecycleTypeQuery = new() { PageRequest = pageRequest };
            RecycleTypeListModel result = await Mediator.Send(getListRecycleTypeQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdRecycleTypeQuery getByIdRecycleTypeQuery)
        {
            RecycleTypeDto result = await Mediator.Send(getByIdRecycleTypeQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] Dynamic? dynamic = null)
        {
            GetListRecycleTypeByDynamicQuery getListRecycleTypeByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            RecycleTypeListModel result = await Mediator.Send(getListRecycleTypeByDynamicQuery);
            return Ok(result);
        }
    }
}
