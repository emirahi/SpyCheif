using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using SpyCheif.Persistance.EntityFramework.Base;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.AssetTypeRepo
{
    public class EfCoreAssetTypeWriteRepository : EfCoreBaseWriteRepository<AssetType>, IWriteAssetTypeRepository
    {
        public EfCoreAssetTypeWriteRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
        }
    }
}
