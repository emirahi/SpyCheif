using MediatR;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch
{
    public class AssetGetOfSearchQueryRequest : IRequest<AssetGetOfSearchQueryResponse>
    {
        public Guid ProjectId { get; set; }
        public Guid? AssetTypeId { get; set; }
        public string? match { get; set; }
        public bool uniq { get; set; } = false;
    }
}
