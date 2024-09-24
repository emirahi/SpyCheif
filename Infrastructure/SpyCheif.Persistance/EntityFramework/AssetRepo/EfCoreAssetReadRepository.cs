using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.AssetRepo
{
    public class EfCoreAssetReadRepository : EfCoreBaseReadRepository<Asset>, IReadAssetRepository
    {
        public EfCoreAssetReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
