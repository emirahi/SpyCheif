using SpyCheif.Domain.Entity;
using System.Linq.Expressions;

namespace SpyCheif.Application.BaseRdms
{
    public interface IBaseRdmsReadRepository<T> where T : BaseEntity, new()
    {

        public IEnumerable<T> GetAll(bool? isActive = null);
        public IEnumerable<T> GetAll(Guid id, bool? isActive = null);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, bool? isActive = null);

        public T? Get(Expression<Func<T, bool>> filter, bool? isActive = null);
        public T? Get(Guid id, bool? isActive = null);

    }
}
