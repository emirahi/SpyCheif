using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Command.TransferCommand.FileDelete;
using SpyCheif.Application.Feature.Command.TransferCommand.FileUpload;
using SpyCheif.Application.Feature.Query.TransferQuery.Get;
using SpyCheif.Application.Feature.Query.TransferQuery.GetAll;
using SpyCheif.Application.Feature.Query.TransferQuery.GetFile;
using SpyCheif.Application.Feature.Query.TransferQuery.GetFiles;

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
        public async Task<IActionResult> Get([FromQuery] TransferGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] TransferGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFiles([FromQuery]TransferGetFilesRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetFile([FromQuery]TransferGetFileRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> FileDelete([FromQuery]TransferFileDeleteRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FileUpload(TransferFileUploadRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
