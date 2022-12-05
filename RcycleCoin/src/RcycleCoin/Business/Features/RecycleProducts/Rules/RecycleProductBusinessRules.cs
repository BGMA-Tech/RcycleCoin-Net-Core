using Business.Features.RecycleProducts.Constants;
using Business.Features.RecycleTypes.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Features.RecycleProducts.Rules
{
    public class RecycleProductBusinessRules:BaseBusinessRules
    {
        private readonly IRecycleProductDal _recycleProductDal;
        private readonly IRecycleTypeDal _recycleTypeDal;

        public RecycleProductBusinessRules(IRecycleProductDal recycleProductDal, IRecycleTypeDal recycleTypeDal)
        {
            _recycleProductDal = recycleProductDal;
            _recycleTypeDal = recycleTypeDal;
        }

        public async Task RecycleProductMustBeAvailable()
        {
            List<RecycleProduct>? results = _recycleProductDal.GetAll();
            if (results.Count <= 0) throw new BusinessException(RecycleProductMessages.RecycleProductNotFound);
        }

        public async Task RecycleProductIdMustBeAvailable(int id)
        {
            RecycleProduct? result = await _recycleProductDal.GetAsync(r => r.Id == id);
            if (result == null) throw new BusinessException(RecycleProductMessages.RecycleProductNotFound);
        }
        public async Task RecycleProductNameMustNotExist(string recycleName)
        {
            RecycleProduct? result = await _recycleProductDal.GetAsync(r => r.RecycleName == recycleName);
            if (result != null) throw new BusinessException(RecycleProductMessages.RecycleProductAlreadyAvailable);
        }
        public async Task RecycleTypeIdMustBeAvailable(int id)
        {
            RecycleType? result = await _recycleTypeDal.GetAsync(r => r.Id == id);
            if (result == null) throw new BusinessException(RecycleTypeMessages.RecycleTypeNotFound);
        }
    }
}
