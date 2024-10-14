using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Add
{
    public class AssetTypeAddCommandResponse:BaseResponse
    {
        public AssetTypeDto AssetType { get; set; }
    }
}
