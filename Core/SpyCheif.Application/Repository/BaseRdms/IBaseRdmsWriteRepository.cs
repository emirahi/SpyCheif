﻿using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.BaseRdms
{
    public interface IBaseRdmsWriteRepository<T> where T : BaseEntity, new()
    {
        public T Add(T entity);
        public void AddList(List<T> entities);
        public Task<T> AddAsync(T entity);
        public Task AddListAsync(List<T> entities);

        public T Update(T entity);
        public void UpdateList(List<T> entities);

        public T? Delete(Guid id);
        public void DeleteRange(List<Guid> guids);

        public T? SetActive(Guid id);
        public T? SetPassive(Guid id);

        public int saveChanges();

    }
}
