using MediatR;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFile
{
    public class TransferGetFileRequest:IRequest<TransferGetFileResponse>
    {
        public Guid FileId { get; set; }
    }
}
