using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.AssetTypeRepo
{
    public class EfCoreAssetTypeWriteRepository : EfCoreBaseWriteRepository<AssetType>, IWriteAssetTypeRepository
    {
        public EfCoreAssetTypeWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
