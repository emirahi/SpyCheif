using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.FileStorageRepo
{
    public class EfCoreFileStorageWriteRepository : EfCoreBaseWriteRepository<FileStorage>, IWriteFileStorageRepository
    {
        public EfCoreFileStorageWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
