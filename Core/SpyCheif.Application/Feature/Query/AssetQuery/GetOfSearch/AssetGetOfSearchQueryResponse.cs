using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch
{
    public class AssetGetOfSearchQueryResponse:BaseResponse
    {
        public List<AssetDto> Assets{ get; set; }
    }
}
