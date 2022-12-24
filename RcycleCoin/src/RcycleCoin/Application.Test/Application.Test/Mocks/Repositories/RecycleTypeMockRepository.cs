using Core.TestHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Moq;

namespace Application.Mocks.Repositories
{
    public class RecycleTypeMockRepository
    {
        public Mock<IRecycleTypeDal> GetRepository()
        {
            var recycleTypes = new List<RecycleType>
            {
                new RecycleType
                {
                    Id = 1,
                    RecycleTypeName = "Şişe"
                },
                new RecycleType
                {
                    Id = 2,
                    RecycleTypeName = "Pil"
                },
                new RecycleType
                {
                    Id = 3,
                    RecycleTypeName = "Cam"
                },
                new RecycleType
                {
                    Id = 4,
                    RecycleTypeName = "Kutu"
                },
            };

            return MockRepositoryHelper.GetRepository<IRecycleTypeDal, RecycleType>(recycleTypes);
        }
    }
}
