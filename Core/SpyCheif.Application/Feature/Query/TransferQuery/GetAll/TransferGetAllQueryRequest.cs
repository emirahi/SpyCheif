using MediatR;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetAll
{
    public class TransferGetAllQueryRequest:IRequest<TransferGetAllQueryResponse>
    {
        public string AppName { get; set; }
    }
}
