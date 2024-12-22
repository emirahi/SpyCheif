using SpyCheif.Application.Enum;

namespace SpyCheif.Application.Dto.AssetDtos
{
    public  class FileAssetDto
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
        public string Path { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string Key { get; set; }
        public string? SingleListSeparator { get; set; }

    }
}
