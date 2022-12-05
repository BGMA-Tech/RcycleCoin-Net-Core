using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRecycleProductDal:IRepository<RecycleProduct>,IAsyncRepository<RecycleProduct>
    {
    }
}
