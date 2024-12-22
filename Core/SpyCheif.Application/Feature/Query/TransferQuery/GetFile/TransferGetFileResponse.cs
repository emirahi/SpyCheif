using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFile
{
    public class TransferGetFileResponse : BaseResponse
    {
        public FileUploadResultDto file { get; set; }
    }
}