using Business.Features.RecycleProducts.Constants;
using Business.Features.UserRecycleProducts.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Features.UserRecycleProducts.Rules
{
    public class UserRecycleProductBusinessRules:BaseBusinessRules
    {
        private readonly IUserRecycleProductDal _userRecycleProductDal;
        private readonly IRecycleProductDal _recycleProductDal;

        public UserRecycleProductBusinessRules(IUserRecycleProductDal userRecycleProductDal, IRecycleProductDal recycleProductDal)
        {
            _userRecycleProductDal = userRecycleProductDal;
            _recycleProductDal = recycleProductDal;
        }

        public async Task UserRecycleProductMustBeAvailable()
        {
            List<UserRecycleProduct>? results = _userRecycleProductDal.GetAll();
            if (results.Count <= 0) throw new BusinessException(UserRecycleProductMessages.UserRecycleProductNotFound);
        }

        public async Task UserRecycleProductIdMustBeAvailable(int id)
        {
            UserRecycleProduct? result = await _userRecycleProductDal.GetAsync(r => r.Id == id);
            if (result == null) throw new BusinessException(UserRecycleProductMessages.UserRecycleProductNotFound);
        }

        public async Task RecycleProductIdMustBeAvailable(int id)
        {
            RecycleProduct? result = await _recycleProductDal.GetAsync(r => r.Id == id);
            if (result == null) throw new BusinessException(RecycleProductMessages.RecycleProductNotFound);
        }
    }
}
