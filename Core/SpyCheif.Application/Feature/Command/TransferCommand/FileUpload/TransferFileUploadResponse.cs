using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileUpload
{
    public class TransferFileUploadResponse : BaseResponse
    {
        public List<string> keys { get; set; }
        public List<Dictionary<string, object>> values { get; set; }
    }
}
