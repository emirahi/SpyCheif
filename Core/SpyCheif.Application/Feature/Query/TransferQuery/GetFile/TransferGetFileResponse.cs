using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFile
{
    public class TransferGetFileResponse : BaseResponse
    {
        public FileUploadResultDto file { get; set; }
        public List<string> keys { get; set; }
        public object values { get; set; }

    }
}