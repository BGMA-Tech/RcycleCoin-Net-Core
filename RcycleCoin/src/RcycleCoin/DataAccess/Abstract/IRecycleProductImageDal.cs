using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IRecycleProductImageDal : IRepository<RecycleProductImage>, IAsyncRepository<RecycleProductImage>
    {
    }
}
