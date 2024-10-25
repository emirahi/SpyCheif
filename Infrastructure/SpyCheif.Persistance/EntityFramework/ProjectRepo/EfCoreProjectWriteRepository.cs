using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.ProjectRepo
{
    public class EfCoreProjectWriteRepository : EfCoreBaseWriteRepository<Project>, IWriteProjectRepository
    {
        public EfCoreProjectWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
