using MediatR;
using Microsoft.AspNetCore.Http;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileUpload
{
    public class TransferFileUploadRequest : IRequest<TransferFileUploadResponse>
    {
        public IFormFile file { get; set; }
    }
}
