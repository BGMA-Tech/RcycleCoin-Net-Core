using Business.Features.RecycleTypes.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Features.RecycleTypes.Rules
{
    public class RecycleTypeBusinessRules:BaseBusinessRules
    {
        private readonly IRecycleTypeDal _recycleTypeDal;

        public RecycleTypeBusinessRules(IRecycleTypeDal recycleTypeDal)
        {
            _recycleTypeDal = recycleTypeDal;
        }

        public async Task RecycleTypeMustBeAvailable()
        {
            List<RecycleType>? results = _recycleTypeDal.GetAll();
            if (results.Count <= 0) throw new BusinessException(RecycleTypeMessages.RecycleTypeNotFound);
        }

        public async Task RecycleTypeIdMustBeAvailable(int id)
        {
            RecycleType? result = await _recycleTypeDal.GetAsync(r => r.Id == id);
            if (result == null) throw new BusinessException(RecycleTypeMessages.RecycleTypeNotFound);
        }
        public async Task RecycleTypeNameMustNotExist(string recycleTypeName)
        {
            RecycleType? result = await _recycleTypeDal.GetAsync(r => r.RecycleTypeName == recycleTypeName);
            if (result != null) throw new BusinessException(RecycleTypeMessages.RecycleTypeAlreadyAvailable);
        }
    }
}
