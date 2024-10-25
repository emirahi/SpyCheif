using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.AssetTypeRepo
{
    public class EfCoreAssetTypeReadRepository : EfCoreBaseReadRepository<AssetType>, IReadAssetTypeRepository
    {
        public EfCoreAssetTypeReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
