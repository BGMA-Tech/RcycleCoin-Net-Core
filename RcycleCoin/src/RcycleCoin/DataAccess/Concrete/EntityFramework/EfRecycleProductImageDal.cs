using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRecycleProductImageDal : EfRepositoryBase<RecycleProductImage, RecycleCoinContext>, IRecycleProductImageDal
    {
        public EfRecycleProductImageDal(RecycleCoinContext context) : base(context)
        {
        }
    }
}
