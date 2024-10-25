using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Update
{
    public class AssetTypeUpdateCommandResponse : BaseResponse
    {
        public AssetTypeDto AssetType { get; set; }
    }
}
