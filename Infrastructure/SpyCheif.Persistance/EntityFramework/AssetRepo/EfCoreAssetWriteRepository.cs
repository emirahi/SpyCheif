using SpyCheif.Application.BaseRdms;
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
    public class EfCoreAssetWriteRepository : EfCoreBaseWriteRepository<Asset>, IWriteAssetRepository
    {
        public EfCoreAssetWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
