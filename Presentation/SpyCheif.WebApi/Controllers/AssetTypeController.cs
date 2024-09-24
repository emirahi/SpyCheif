using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Application.Feature.Command.AssetCommand.Update;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Add;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Delete;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Update;
using SpyCheif.Application.Feature.Query.AssetQuery.Get;
using SpyCheif.Application.Feature.Query.AssetQuery.GetAll;
using SpyCheif.Application.Feature.Query.AssetTypeQuery.Get;
using SpyCheif.Application.Feature.Query.AssetTypeQuery.GetAll;

namespace SpyCheif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssetTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]AssetTypeGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery]AssetTypeGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] AssetTypeAddCommandRequest assetAddCommand)
        {
            var result = await _mediator.Send(assetAddCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] AssetTypeUpdateCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody]AssetTypeDeleteCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
