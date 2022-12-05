using AutoMapper;
using Business.Features.RecycleProducts.Commands.CreateRecycleProduct;
using Business.Features.RecycleProducts.Commands.DeleteRecycleProduct;
using Business.Features.RecycleProducts.Commands.UpdateRecycleProduct;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Models;
using Core.DataAccess.EntityFramework.Paging;
using Entities.Concrete;

namespace Business.Features.RecycleProducts.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RecycleProduct, CreatedRecycleProductDto>().ReverseMap();
            CreateMap<RecycleProduct, CreateRecycleProductCommand>().ReverseMap();

            CreateMap<RecycleProduct, DeletedRecycleProductDto>().ReverseMap();
            CreateMap<RecycleProduct, DeleteRecycleProductCommand>().ReverseMap();

            CreateMap<RecycleProduct, UpdatedRecycleProductDto>().ReverseMap();
            CreateMap<RecycleProduct, UpdateRecycleProductCommand>().ReverseMap();

            CreateMap<RecycleProduct, RecycleProductDto>()
                .ForMember(u => u.RecycleTypeName , opt => opt.MapFrom( u=> u.RecycleType.RecycleTypeName))
                .ReverseMap();
            CreateMap<RecycleProduct, RecycleProductListDto>()
                .ForMember(u => u.RecycleTypeName, opt => opt.MapFrom(u => u.RecycleType.RecycleTypeName))
                .ReverseMap();
            CreateMap<IPaginate<RecycleProduct>, RecycleProductListModel>().ReverseMap();
        }
    }
}
