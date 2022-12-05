using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserRecycleProductDal : EfRepositoryBase<UserRecycleProduct, RecycleCoinContext>, IUserRecycleProductDal
    {
        public EfUserRecycleProductDal(RecycleCoinContext context) : base(context)
        {
        }
    }
}
