using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandRequest : IRequest<AssetAddOfMultiCommandResponse>
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public string Value { get; set; }
    }
}
