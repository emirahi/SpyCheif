using MediatR;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileDelete
{
    public class TransferFileDeleteRequest:IRequest<TransferFileDeleteResponse>
    {
        public Guid FileId { get; set; }
    }
}