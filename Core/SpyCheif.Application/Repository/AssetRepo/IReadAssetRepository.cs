using SpyCheif.Application.BaseRdms;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Repository.AssetRepo
{
    public interface IReadAssetRepository : IBaseRdmsReadRepository<Asset>
    {
        public IEnumerable<Asset> GetAll(Guid projectId, bool uniq = false, bool? isActive = null);
    }
}
