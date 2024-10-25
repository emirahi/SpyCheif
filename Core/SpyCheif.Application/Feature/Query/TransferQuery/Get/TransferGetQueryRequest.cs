using MediatR;

namespace SpyCheif.Application.Feature.Query.TransferQuery.Get
{
    public class TransferGetQueryRequest : IRequest<TransferGetQueryResponse>
    {
        public string AppName { get; set; }
        public string Id { get; set; }

    }
}
