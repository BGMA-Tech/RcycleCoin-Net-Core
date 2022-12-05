using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRecycleProductDal : EfRepositoryBase<RecycleProduct, RecycleCoinContext>, IRecycleProductDal
    {
        public EfRecycleProductDal(RecycleCoinContext context) : base(context)
        {
        }
    }
}
