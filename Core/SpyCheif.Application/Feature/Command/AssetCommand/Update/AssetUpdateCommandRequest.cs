using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Update
{
    public class AssetUpdateCommandRequest: IRequest<AssetUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid AssetTypeId { get; set; }
        public string Value { get; set; }

    }
}
