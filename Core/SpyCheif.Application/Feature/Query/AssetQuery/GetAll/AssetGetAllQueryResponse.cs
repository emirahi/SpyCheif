using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetAll
{
    public class AssetGetAllQueryResponse:BaseResponse
    {
        public List<AssetDto> Assets { get; set; }
    }
}
