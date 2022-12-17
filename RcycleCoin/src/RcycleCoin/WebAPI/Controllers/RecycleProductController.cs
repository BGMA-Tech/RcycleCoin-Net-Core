using Business.Features.RecycleProducts.Commands.CreateRecycleProduct;
using Business.Features.RecycleProducts.Commands.DeleteRecycleProduct;
using Business.Features.RecycleProducts.Commands.UpdateRecycleProduct;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Models;
using Business.Features.RecycleProducts.Queries.GetByIdRecycleProduct;
using Business.Features.RecycleProducts.Queries.GetListRecycleProduct;
using Business.Features.RecycleProducts.Queries.GetListRecycleProductByDynamic;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Core.Helper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleProductController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateRecycleProductCommand createRecycleProductCommand)
        {
            CreatedRecycleProductDto result = await Mediator.Send(createRecycleProductCommand);
            return Created("", result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRecycleProductCommand deletedRecycleProductCommand)
        {
            DeletedRecycleProductDto result = await Mediator.Send(deletedRecycleProductCommand);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRecycleProductCommand updatedRecycleProductCommand)
        {
            UpdatedRecycleProductDto result = await Mediator.Send(updatedRecycleProductCommand);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListRecycleProductQuery getListRecycleProductQuery = new() { PageRequest = pageRequest };
            RecycleProductListModel result = await Mediator.Send(getListRecycleProductQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdRecycleProductQuery getByIdRecycleProductQuery)
        {
            RecycleProductDto result = await Mediator.Send(getByIdRecycleProductQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] Dynamic? dynamic = null)
        {
            GetListRecycleProductByDynamicQuery getListRecycleProductByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            RecycleProductListModel result = await Mediator.Send(getListRecycleProductByDynamicQuery);
            return Ok(result);
        }
    }
}
