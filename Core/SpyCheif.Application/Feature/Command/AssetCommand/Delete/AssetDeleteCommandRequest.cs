using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Delete
{
    public class AssetDeleteCommandRequest:IRequest<AssetDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
