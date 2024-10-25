namespace SpyCheif.Application.Dto.ServiceDatabaseDtos
{
    public class ServiceDatabaseDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollentionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
