using Application.Commands;
using Application.DTO;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Services.Items.Api.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            var result = await _mediator.Send(new GetAllItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetItemQuery() { Id = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateItemCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateItemCommand command)
        {
            command.Id=id;
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteItemCommand() { Id = id });
            return NoContent();
        }
    }
}