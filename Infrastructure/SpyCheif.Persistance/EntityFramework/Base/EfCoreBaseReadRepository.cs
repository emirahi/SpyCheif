using Microsoft.EntityFrameworkCore;
using SpyCheif.Application.BaseRdms;
using SpyCheif.Domain.Entity;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.Base
{
    public class EfCoreBaseReadRepository<T> : IBaseRdmsReadRepository<T>
        where T : BaseEntity, new()
    {
        public DbSet<T> _table;
        public SpyChiefDbContext _dbContext;
        public EfCoreBaseReadRepository(SpyChiefDbContext spyChiefDbContext)
        {
            _dbContext = spyChiefDbContext;
            _table = _dbContext.Set<T>();
        }


        public virtual T? Get(Expression<Func<T, bool>> filter, bool? isActive = null)
        {
            return isActive != null 
                ? _table.Where(filter).Where(entity => entity.IsActive == isActive).FirstOrDefault()
                : _table.Where(filter).FirstOrDefault();
        }

        public virtual T? Get(Guid id, bool? isActive = null)
        {
            return isActive != null
                ? _table.Where(entity => entity.Id == id && entity.IsActive == isActive).FirstOrDefault()
                : _table.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll(Guid id, bool? isActive = null)
        {
            return isActive == null 
                ? _table.Where(entity => entity.Id == id)
                : _table.Where(entity => entity.Id == id && entity.IsActive == isActive);
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, bool? isActive = null)
        {
            return isActive == null
                ? _table.Where(filter)
                : _table.Where(filter).Where(entity => entity.IsActive == isActive);
        }

        public virtual IEnumerable<T> GetAll(bool? isActive = null)
        {
            return isActive == null
                ? _table
                : _table.Where(entity => entity.IsActive == isActive);
        }

    }
}
