using MediatR;
using Microsoft.AspNetCore.Http;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Utils.Storage;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileUpload
{
    public class TransferFileUploadHandler : IRequestHandler<TransferFileUploadRequest, TransferFileUploadResponse>
    {
        private IHttpContextAccessor _httpContext;
        private IFileStorage _fileStorage;
        public TransferFileUploadHandler(IHttpContextAccessor httpContext, IFileStorage fileStorage)
        {
            _httpContext = httpContext;
            _fileStorage = fileStorage;
        }

        public async Task<TransferFileUploadResponse> Handle(TransferFileUploadRequest request, CancellationToken cancellationToken)
        {
            string host = _httpContext.HttpContext.Request.Host.Host;
            FileUploadResultDto? result = _fileStorage.Upload(request.file, host);
            if (result == null)
                return new() { Status = false, Message = "" };

            string? jsons = _fileStorage.StreamFullRead(result.LocalPath);
            if (jsons != null)
            {
                List<string> keys = _fileStorage.GetJsonKeys(jsons).ToList();
                var values = _fileStorage.ReadToJson(jsons, 10);
                return new() { keys = keys, values = values, Status = true, Message = "" };
            }
            return new() { Status = false, Message = "" };

        }
    }
}
