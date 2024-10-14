using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandResponse : BaseResponse
    {
        public AssetDto Asset { get; set; } 
    }
}
