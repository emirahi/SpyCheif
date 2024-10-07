

using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.AssetQuery.Get
{
    public class AssetGetQueryResponse:BaseResponse
    {
        public AssetDto Asset { get; set; }
    }
}
