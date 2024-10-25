using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistance.EntityFramework.ProjectRepo
{
    public class EfCoreProjectReadRepository : EfCoreBaseReadRepository<Project>, IReadProjectRepository
    {
        public EfCoreProjectReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
