using Business.Features.UserRecycleProducts.Commands.CreateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.DeleteUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.UpdateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Models;
using Business.Features.UserRecycleProducts.Queries.GetByIdUserRecycleProduct;
using Business.Features.UserRecycleProducts.Queries.GetListUserRecycleProduct;
using Core.Application.Requests;
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
    }
}
