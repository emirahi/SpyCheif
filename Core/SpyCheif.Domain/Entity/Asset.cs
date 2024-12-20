﻿namespace SpyCheif.Domain.Entity
{
    public class Asset : BaseEntity
    {
        public Guid AssetTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public string Value { get; set; }
        public AssetType Type { get; set; }
        public Project Project { get; set; }
    }
}
