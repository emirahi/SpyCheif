using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.TransferRepo
{
    public class EfCoreFileStorageReadRepository : EfCoreBaseReadRepository<FileStorage>, IReadFileStorageRepository
    {
        public EfCoreFileStorageReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
