using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Query.TransferQuery.Get;
using SpyCheif.Application.Feature.Query.TransferQuery.GetAll;

namespace SpyCheif.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery]TransferGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery]TransferGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
