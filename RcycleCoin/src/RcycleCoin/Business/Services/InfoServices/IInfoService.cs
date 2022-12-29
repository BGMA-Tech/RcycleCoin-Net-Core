﻿using Business.Services.InfoServices.Dtos;
using Core.Utilities.JsonResults.Abstract;
using Core.Utilities.JsonResults.Concrete;

namespace Business.Services.InfoServices
{
    public interface IInfoService
    {
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> Add(CreatedInfoDto createdInfoDto);
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> Update(string id,UpdateInfoDto updateInfoDto);
        public Task<IJsonDataResult<ResultDataJson<InfoDto>>> GetById(string id);
    }
}
