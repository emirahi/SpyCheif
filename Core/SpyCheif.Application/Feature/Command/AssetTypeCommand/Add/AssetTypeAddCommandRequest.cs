using MediatR;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Add
{
    public class AssetTypeAddCommandRequest : IRequest<AssetTypeAddCommandResponse>
    {
        public string TypeName { get; set; }
    }
}
