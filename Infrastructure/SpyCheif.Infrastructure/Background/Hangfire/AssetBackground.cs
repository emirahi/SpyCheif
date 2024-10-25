using SpyCheif.Application.BackgroundJob;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Infrastructure.Background.Hangfire
{
    public class AssetBackground : IAssetBackground
    {
        private readonly IWriteAssetRepository _writeAssetRepository;
        public AssetBackground(IWriteAssetRepository writeAssetRepository)
        {
            _writeAssetRepository = writeAssetRepository;
        }

        public void Add(List<Asset> assets)
        {
            foreach (var asset in assets)
            {
                _writeAssetRepository.Add(asset);
            }
            _writeAssetRepository.saveChanges();
        }
    }
}
