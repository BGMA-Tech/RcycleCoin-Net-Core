using Business.Features.UserRecycleProducts.Commands.CreateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.DeleteUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.UpdateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Models;
using Business.Features.UserRecycleProducts.Queries.GetByIdUserRecycleProduct;
using Business.Features.UserRecycleProducts.Queries.GetListUserRecycleProduct;
using Business.Features.UserRecycleProducts.Queries.GetListUserRecycleProductByDynamic;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRecycleProductController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserRecycleProductCommand createUserRecycleProductCommand)
        {
            CreatedUserRecycleProductDto result = await Mediator.Send(createUserRecycleProductCommand);
            return Created("", result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRecycleProductCommand deletedUserRecycleProductCommand)
        {
            DeletedUserRecycleProductDto result = await Mediator.Send(deletedUserRecycleProductCommand);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRecycleProductCommand updatedUserRecycleProductCommand)
        {
            UpdatedUserRecycleProductDto result = await Mediator.Send(updatedUserRecycleProductCommand);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserRecycleProductQuery getListUserRecycleProductQuery = new() { PageRequest = pageRequest };
            UserRecycleProductListModel result = await Mediator.Send(getListUserRecycleProductQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserRecycleProductQuery getByIdUserRecycleProductQuery)
        {
            UserRecycleProductDto result = await Mediator.Send(getByIdUserRecycleProductQuery);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                      [FromBody] Dynamic? dynamic = null)
        {
            GetListUserRecycleProductByDynamicQuery getListUserRecycleProductByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            UserRecycleProductListModel result = await Mediator.Send(getListUserRecycleProductByDynamicQuery);
            return Ok(result);
        }
    }
}
