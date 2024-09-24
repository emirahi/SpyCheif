using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Add
{
    public class AssetTypeAddCommandRequest : IRequest<AssetTypeAddCommandResponse>
    {
        public string TypeName { get; set; }
    }
}
