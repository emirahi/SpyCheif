using Microsoft.EntityFrameworkCore;
using SpyCheif.Application.Base;
using SpyCheif.Domain.Entity;
using SpyCheiif.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Persistance.EntityFramework.Base
{
    public class EfCoreBaseWriteRepository<T> : IBaseWriteRepository<T>
        where T : BaseEntity, new()
    {
        public DbSet<T> _Table;
        public SpyChiefDbContext _dbContext;
        public EfCoreBaseWriteRepository(SpyChiefDbContext spyChiefDbContext)
        {
            _dbContext = spyChiefDbContext;
            _Table = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            T resultT = _Table.Add(entity).Entity;
            return resultT;
        }

        public async Task<T> AddAsync(T entity)
        {
            T resultT = (await _Table.AddAsync(entity)).Entity;
            return resultT;
        }

        public void AddList(List<T> entities)
        {
            _Table.AddRange(entities);
        }

        public async Task AddListAsync(List<T> entities)
        {
            await _Table.AddRangeAsync(entities);
        }

        public T Update(T entity)
        {
            T resultT = _Table.Update(entity).Entity;
            return resultT;
        }

        public void UpdateList(List<T> entities)
        {
            _Table.UpdateRange(entities);
        }


        public T? SetActive(Guid id)
        {
            T? resultT = _Table.Where(entity => entity.Id == id).FirstOrDefault();
            if (resultT != null)
            {
                resultT.IsActive = true;
            }
            return null;
        }

        public T? SetPassive(Guid id)
        {
            T? resultT = _Table.Where(entity => entity.Id == id).FirstOrDefault();
            if (resultT != null)
            {
                resultT.IsActive = false;
            }
            return null;
        }

        public int saveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public T? Delete(Guid id)
        {
            T? entity = _Table.FirstOrDefault(entity => entity.Id == id);
            if (entity != null)
            {
                T resultT = _Table.Remove(entity).Entity;
                return resultT;
            }
            return null;
        }

        public void DeleteRange(List<Guid> guids)
        {
            foreach (var id in guids)
            {
                T? entity = _Table.FirstOrDefault(entity => entity.Id == id);
                if (entity != null)
                {
                    _Table.Remove(entity);
                }
            }
        }


    }
}
