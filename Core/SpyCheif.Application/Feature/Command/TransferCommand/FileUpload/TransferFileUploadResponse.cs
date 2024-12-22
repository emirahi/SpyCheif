using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileUpload
{
    public class TransferFileUploadResponse : BaseResponse
    {
        public Guid FileId { get; set; }
        public List<string> keys { get; set; }
        public object values { get; set; }
    }
}
