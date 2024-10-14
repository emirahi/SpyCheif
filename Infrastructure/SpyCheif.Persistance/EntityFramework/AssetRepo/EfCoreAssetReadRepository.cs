using Microsoft.EntityFrameworkCore;
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
        private SpyChiefDbContext _spyChiefDbContext;
        public EfCoreAssetReadRepository(SpyChiefDbContext spyChiefDbContext) : base(spyChiefDbContext)
        {
            _spyChiefDbContext = spyChiefDbContext;
        }

        public IEnumerable<Asset> GetAll(Guid projectId,bool uniq = false,bool? isActive = null)
        {
            IQueryable<Asset> assets = isActive != null
                ? _spyChiefDbContext.Assets.Where(asset => asset.IsActive == isActive && asset.ProjectId == projectId)
                : _spyChiefDbContext.Assets.Where(asset => asset.ProjectId == projectId);

            var active = uniq ? assets.AsSplitQuery().AsEnumerable().DistinctBy(asset => asset.Value.ToLower().Trim()) : assets.AsSplitQuery().AsEnumerable();
            var returned = active.ToList();
            return returned;
        }

    }
}
