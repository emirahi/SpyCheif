namespace SpyCheif.Application.Dto.AssetDtos
{
    public class AssetDto : IDto
    {
        public Guid Id { get; set; }
        public Guid AssetTypeId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
