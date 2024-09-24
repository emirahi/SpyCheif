using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.ServiceDatabaseRepo
{
    public class EfCoreServiceDatabaseReadRepository : EfCoreBaseReadRepository<ServiceDatabase>, IReadServiceDatabaseRepository
    {
        public EfCoreServiceDatabaseReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
