using Microsoft.EntityFrameworkCore;
using SpyCheif.Application.Base;
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
    public class EfCoreBaseReadRepository<T> : IBaseReadRepository<T>
        where T : BaseEntity, new()
    {
        public DbSet<T> _table;
        public SpyChiefDbContext _dbContext;
        public EfCoreBaseReadRepository(SpyChiefDbContext spyChiefDbContext)
        {
            _dbContext = spyChiefDbContext;
            _table = _dbContext.Set<T>();
        }


        public T? Get(Expression<Func<T, bool>> filter, bool? isActive = true)
        {
            return _table.Where(filter).Where(entity => entity.IsActive == isActive).FirstOrDefault();
        }

        public T? Get(Guid id, bool? isActive = true)
        {
            return _table.Where(entity => entity.Id == id && entity.IsActive == isActive).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Guid id, bool? isActive = null)
        {
            return isActive == null 
                ? _table.Where(entity => entity.Id == id).ToList() 
                : _table.Where(entity => entity.Id == id && entity.IsActive == isActive).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, bool? isActive = null)
        {
            return isActive == null
                ? _table.Where(filter).ToList()
                : _table.Where(filter).Where(entity => entity.IsActive == isActive).ToList();
        }
    }
}
