using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.ServiceDatabaseRepo
{
    public class EfCoreServiceDatabaseWriteRepository : EfCoreBaseWriteRepository<ServiceDatabase>, IWriteServiceDatabaseRepository
    {
        public EfCoreServiceDatabaseWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
