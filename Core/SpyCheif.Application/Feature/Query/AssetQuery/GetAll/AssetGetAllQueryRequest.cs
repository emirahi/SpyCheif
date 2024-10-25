using MediatR;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetAll
{
    public class AssetGetAllQueryRequest : IRequest<AssetGetAllQueryResponse>
    {
        public Guid ProjectId { get; set; }
        public bool Uniq { get; set; } = false;
    }
}
