namespace SpyCheif.Application.Dto.AssetTypeDtos
{
    public class AssetTypeDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
