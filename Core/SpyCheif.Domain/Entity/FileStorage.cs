namespace SpyCheif.Domain.Entity
{
    public class FileStorage : BaseEntity
    {
        public string UniqName { get; set; }
        public string FileName { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
        public string FileType { get; set; }
    }
}
