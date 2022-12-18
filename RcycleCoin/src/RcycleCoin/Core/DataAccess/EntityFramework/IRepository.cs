using Core.Entities;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : Entity
    {
        T? Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

        /*T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
         IIncludableQueryable<T, object>>? include = null, bool enableTracking = true);
        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                             int index = 0, int size = 10,
                             bool enableTracking = true);
        IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                      int index = 0, int size = 10, bool enableTracking = true);*/
    }
}