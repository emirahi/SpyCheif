using SpyCheif.Application.Enum;

namespace SpyCheif.Application.Dto.FileStorage
{
    public  class FileUploadDto
    {
        public string UniqName { get; set; }
        public string FileName { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
    }
}
