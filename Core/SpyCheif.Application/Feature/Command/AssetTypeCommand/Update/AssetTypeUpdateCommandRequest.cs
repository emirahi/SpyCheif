using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Update
{
    public class AssetTypeUpdateCommandRequest:IRequest<AssetTypeUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
    }
}
