using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Delete
{
    public class AssetTypeDeleteCommandRequest:IRequest<AssetTypeDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
