using MediatR;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.Get
{
    public class AssetTypeGetQueryRequest : IRequest<AssetTypeGetQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
