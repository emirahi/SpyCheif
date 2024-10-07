using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Event
{
    public  class AssetTypeAddedEvent
    {
        public string Value { get; set; }
        public AssetType AssetTypeId { get; set; }
    }
}
