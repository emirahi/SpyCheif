using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Base
{
    public interface IBaseWriteRepository<T> where T : BaseEntity,new()
    {
        public T Add(T entity);
        public void AddList(List<T> entities);
        public Task<T> AddAsync(T entity);
        public Task AddListAsync(List<T> entities);

        public T Update(T entity);
        public void UpdateList(List<T> entities);

        public T Delete(Guid id);
        public void DeleteRange(List<Guid> guids);

        public T SetActive(Guid id);
        public T SetPassive(Guid id);

        public int saveChanges();

    }
}
