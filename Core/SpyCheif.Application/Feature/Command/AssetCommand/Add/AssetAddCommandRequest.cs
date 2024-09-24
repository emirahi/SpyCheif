using MediatR;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandRequest:IRequest<AssetAddCommandResponse>
    {
        public Guid AssetTypeId { get; set; }
        public string Value { get; set; }
    }
}
