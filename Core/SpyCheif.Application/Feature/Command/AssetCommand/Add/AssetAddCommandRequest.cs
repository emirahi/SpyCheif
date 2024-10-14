using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandRequest:IRequest<AssetAddCommandResponse>
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public string Value { get; set; }
    }
}
