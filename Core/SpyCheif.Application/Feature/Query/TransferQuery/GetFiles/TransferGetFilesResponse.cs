using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFiles
{
    public class TransferGetFilesResponse : BaseResponse
    {
        public List<FileUploadResultDto> files { get; set; }
    }
}
