using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRecycleTypeDal : EfRepositoryBase<RecycleType, RecycleCoinContext>, IRecycleTypeDal
    {
        public EfRecycleTypeDal(RecycleCoinContext context) : base(context)
        {
        }
    }
}
