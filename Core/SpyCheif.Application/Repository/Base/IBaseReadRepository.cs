using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Base
{
    public interface IBaseReadRepository<T> where T : BaseEntity,new()
    {
        
        public IEnumerable<T> GetAll(Guid id,bool? isActive = null);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter,bool? isActive = null);

        public T Get(Expression<Func<T,bool>> filter,bool? isActive = true);
        public T Get(Guid id,bool? isActive = true);

    }
}
