using Business.Services.InfoServices.Dtos;
using Business.Services.TransactionServices.Dtos;
using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.TransactionServices
{
    public interface ITransactionService
    {
        public Task<IJsonDataResult<ResultDataJson<TransactionDto>>> GetById(string id);
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAll();
        public Task<IJsonDataResult<ResultDataJson<List<TransactionDto>>>> GetAllById(string id);
        public Task<IJsonDataResult<ResultDataJson<CreatedTransactionDto>>> Add(CreatedTransactionDto createdTransactionDto);
    }
}
