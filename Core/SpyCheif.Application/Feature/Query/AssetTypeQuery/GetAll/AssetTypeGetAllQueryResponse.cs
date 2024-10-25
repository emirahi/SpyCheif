using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.GetAll
{
    public class AssetTypeGetAllQueryResponse : BaseResponse
    {
        public List<AssetTypeDto> AssetTypes { get; set; }
    }
}
