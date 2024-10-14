using MediatR;

namespace SpyCheif.Application.Feature.Query.AssetQuery.Get
{
    public class AssetGetQueryRequest:IRequest<AssetGetQueryResponse>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
    }
}
