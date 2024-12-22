namespace SpyCheif.Application.Dto.FileStorage
{
    public class FileUploadResultDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string UniqName { get; set; }
        public string FileName { get; set; }
        public string RemotePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
