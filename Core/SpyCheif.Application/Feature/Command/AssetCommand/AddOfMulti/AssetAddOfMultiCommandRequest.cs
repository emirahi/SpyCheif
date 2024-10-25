using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti
{
    public class AssetAddOfMultiCommandRequest : IRequest<AssetAddOfMultiCommandResponse>
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public List<string> Value { get; set; }
    }
}
