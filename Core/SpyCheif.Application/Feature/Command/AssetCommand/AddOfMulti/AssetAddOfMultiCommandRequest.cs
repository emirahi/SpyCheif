﻿using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti
{
    public class AssetAddOfMultiCommandRequest : IRequest<AssetAddOfMultiCommandResponse>
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
        public string Key { get; set; }
        public string? SingleListSeparator { get; set; }

    }
}
