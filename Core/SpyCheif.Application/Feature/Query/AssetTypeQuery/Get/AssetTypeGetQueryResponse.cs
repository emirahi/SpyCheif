using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.Get
{
    public class AssetTypeGetQueryResponse : BaseResponse
    {
        public AssetTypeDto assetType { get; set; }
    }
}
