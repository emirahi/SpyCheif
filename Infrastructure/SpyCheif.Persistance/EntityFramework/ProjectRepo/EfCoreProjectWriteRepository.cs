using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.ProjectRepo
{
    public class EfCoreProjectWriteRepository : EfCoreBaseWriteRepository<Project>, IWriteProjectRepository
    {
        public EfCoreProjectWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
