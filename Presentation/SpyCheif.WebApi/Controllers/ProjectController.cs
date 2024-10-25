using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Command.ProjectCommand.Add;
using SpyCheif.Application.Feature.Command.ProjectCommand.Delete;
using SpyCheif.Application.Feature.Command.ProjectCommand.Update;
using SpyCheif.Application.Feature.Query.ProjectQuery.Get;
using SpyCheif.Application.Feature.Query.ProjectQuery.GetAll;

namespace SpyCheif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] ProjectGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] ProjectGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] ProjectAddCommandRequest assetAddCommand)
        {
            var result = await _mediator.Send(assetAddCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] ProjectUpdateCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] ProjectDeleteCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
