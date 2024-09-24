using MassTransit;
using SpyCheif.Application.Event;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.AssetTypeConsumer.Consumer
{
    public class AssetTypeConsume : IConsumer<AssetTypeAddedEvent>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetRepository _readAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        
        public AssetTypeConsume(
            IWriteAssetRepository writeAssetRepository, 
            IReadAssetRepository readAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetRepository = readAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public Task Consume(ConsumeContext<AssetTypeAddedEvent> context)
        {
            string? value = context.Message.Value;
            Guid type = context.Message.AssetTypeId;

            AssetType assetType = _readAssetTypeRepository.Get(type);
            throw new NotImplementedException();

            Asset? asset = _readAssetRepository.Get(asset => asset.Value.Trim() == value.Trim() && asset.AssetTypeId == type);

            if (asset == null)
            {
                _writeAssetRepository.Add(new() { Value = value, AssetTypeId = type });
                _writeAssetRepository.saveChanges();
            }
            
            return Task.CompletedTask;
        }

    }
}
