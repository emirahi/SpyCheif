using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Update
{
    public class AssetTypeUpdateCommandRequest:IRequest<AssetTypeUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
    }
}
