﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti;
using SpyCheif.Application.Feature.Command.AssetCommand.Delete;
using SpyCheif.Application.Feature.Command.AssetCommand.Update;
using SpyCheif.Application.Feature.Query.AssetQuery.Get;
using SpyCheif.Application.Feature.Query.AssetQuery.GetAll;
using SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch;
using SpyCheif.Application.Utils.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpyCheif.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private IMediator _mediator;
        private IFileStorage _fileStorage;
        public AssetController(
            IMediator mediator,
            IFileStorage fileStorage)
        {
            _mediator = mediator;
            _fileStorage = fileStorage;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] AssetGetAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] AssetGetQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Search([FromBody] AssetGetOfSearchQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert([FromBody] AssetAddCommandRequest assetAddCommand)
        {
            var result = await _mediator.Send(assetAddCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertOfList([FromBody] AssetAddOfMultiCommandRequest assetAddCommand)
        {
            var result = await _mediator.Send(assetAddCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] AssetUpdateCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] AssetDeleteCommandRequest assetUpdateCommand)
        {
            var result = await _mediator.Send(assetUpdateCommand);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
