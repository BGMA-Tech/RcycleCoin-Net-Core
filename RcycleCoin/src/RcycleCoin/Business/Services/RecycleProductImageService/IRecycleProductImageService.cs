using Business.Services.RecycleProductImageService.Dtos;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Services.RecycleProductImageService
{
    public interface IRecycleProductImageService
    {
        IDataResult<CreatedRecycleProductImageDto> Add(IFormFile file);
        IDataResult<RecycleProductImage> GetByImageId(int imageId);
        IDataResult<List<RecycleProductImage>> GetAll();
    }
}
