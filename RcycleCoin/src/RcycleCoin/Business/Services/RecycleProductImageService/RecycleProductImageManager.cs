using AutoMapper;
using Business.Constants;
using Business.Services.RecycleProductImageService.Dtos;
using Core.Helper.FileHelpers;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Services.RecycleProductImageService
{
    public class RecycleProductImageManager : IRecycleProductImageService
    {
        private readonly IFileHelper _fileHelper;
        private readonly IMapper _mapper;
        private readonly IRecycleProductImageDal _recycleProductImageDal;

        public RecycleProductImageManager(IFileHelper fileHelper, IMapper mapper, IRecycleProductImageDal recycleProductImageDal)
        {
            _fileHelper = fileHelper;
            _mapper = mapper;
            _recycleProductImageDal = recycleProductImageDal;
        }

        public IDataResult<CreatedRecycleProductImageDto> Add(IFormFile file)
        {
            var resultOfUpload = _fileHelper.Upload(file, PathConstant.ImagesPath);
            if (!resultOfUpload.Success)
            {
                return new ErrorDataResult<CreatedRecycleProductImageDto>();
            }
            RecycleProductImage recycleProductImage = new RecycleProductImage();
            recycleProductImage.ImagePath = resultOfUpload.Message;

            _recycleProductImageDal.Add(recycleProductImage);
            return new SuccessDataResult<CreatedRecycleProductImageDto>(recycleProductImage.ImagePath);
        }

        public IDataResult<List<RecycleProductImage>> GetAll()
        {
            return new SuccessDataResult<List<RecycleProductImage>>(_recycleProductImageDal.GetAll());
        }

        public IDataResult<RecycleProductImage> GetByImageId(int imageId)
        {
            if(imageId > 0)
            {
                return new SuccessDataResult<RecycleProductImage>(_recycleProductImageDal.Get(c => c.Id == imageId));
            }
            return new ErrorDataResult<RecycleProductImage>("Id must be greater than zero");
        }
    }
}
