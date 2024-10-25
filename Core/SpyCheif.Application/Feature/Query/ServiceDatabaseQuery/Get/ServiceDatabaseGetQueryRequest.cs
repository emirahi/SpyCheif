using MediatR;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get
{
    public class ServiceDatabaseGetQueryRequest : IRequest<ServiceDatabaseGetQueryResponse>
    {
        public Guid ServiceAppId { get; set; }
    }
}
