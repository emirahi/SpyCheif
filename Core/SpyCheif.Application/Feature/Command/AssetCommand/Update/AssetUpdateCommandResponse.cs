using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Update
{
    public class AssetUpdateCommandResponse : BaseResponse
    {
        public AssetDto asset { get; set; }
    }
}
