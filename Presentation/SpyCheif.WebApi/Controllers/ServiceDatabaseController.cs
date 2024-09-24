using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Application.Feature.Command.AssetCommand.Update;
using SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add;
using SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Delete;
using SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update;
using SpyCheif.Application.Feature.Query.AssetQuery.Get;
using SpyCheif.Application.Feature.Query.AssetQuery.GetAll;
using SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get;
using SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.GetAll;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpyCheif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDatabaseController : ControllerBase
    {

        private IMediator _mediator;
        public ServiceDatabaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]ServiceDatabaseGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery]ServiceDatabaseGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody]ServiceDatabaseAddCommandRequest addCommandRequest)
        {
            var result = await _mediator.Send(addCommandRequest);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody]ServiceDatabaseUpdateCommandRequest updateCommandRequest)
        {
            var result = await _mediator.Send(updateCommandRequest);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody]ServiceDatabaseDeleteCommandRequest updateCommandRequest)
        {
            var result = await _mediator.Send(updateCommandRequest);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
