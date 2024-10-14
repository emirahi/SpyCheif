using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Update
{
    public class AssetUpdateCommandRequest: IRequest<AssetUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid AssetTypeId { get; set; }
        public string Value { get; set; }

    }
}
