using AutoMapper;
using Business.Features.RecycleTypes.Commands.CreateRecycleType;
using Business.Features.RecycleTypes.Commands.DeleteRecycleType;
using Business.Features.RecycleTypes.Commands.UpdateRecycleType;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Models;
using Core.DataAccess.EntityFramework.Paging;
using Entities.Concrete;

namespace Business.Features.RecycleTypes.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RecycleType, CreatedRecycleTypeDto>().ReverseMap();
            CreateMap<RecycleType, CreateRecycleTypeCommand>().ReverseMap();

            CreateMap<RecycleType, DeletedRecycleTypeDto>().ReverseMap();
            CreateMap<RecycleType, DeleteRecycleTypeCommand>().ReverseMap();

            CreateMap<RecycleType, UpdatedRecycleTypeDto>().ReverseMap();
            CreateMap<RecycleType, UpdateRecycleTypeCommand>().ReverseMap();

            CreateMap<RecycleType, RecycleTypeDto>().ReverseMap();
            CreateMap<RecycleType, RecycleTypeListDto>().ReverseMap();
            CreateMap<IPaginate<RecycleType>, RecycleTypeListModel>().ReverseMap();
        }
    }
}
