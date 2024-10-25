using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.AssetRepo
{
    public class EfCoreAssetWriteRepository : EfCoreBaseWriteRepository<Asset>, IWriteAssetRepository
    {
        public EfCoreAssetWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
