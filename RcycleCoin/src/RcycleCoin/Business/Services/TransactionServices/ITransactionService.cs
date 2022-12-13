using Business.Services.TransactionServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.TransactionServices
{
    public interface ITransactionService
    {
        public Task<IDataResult<ResultDataJson<TransactionDto>>> GetById(string id);
        public Task<IDataResult<ResultDataJson<List<TransactionDto>>>> GetAll();
        public Task<IDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id);
        public Task<IDataResult<ResultDataJson<TransactionDto>>> Add(CreatedTransactionDto createdTransactionDto);
    }
}
