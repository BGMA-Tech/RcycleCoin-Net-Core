using AutoMapper;
using Business.Features.UserRecycleProducts.Commands.CreateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.DeleteUserRecycleProduct;
using Business.Features.UserRecycleProducts.Commands.UpdateUserRecycleProduct;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Models;
using Core.DataAccess.EntityFramework.Paging;
using Entities.Concrete;

namespace Business.Features.UserRecycleProducts.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRecycleProduct, CreatedUserRecycleProductDto>().ReverseMap();
            CreateMap<UserRecycleProduct, CreateUserRecycleProductCommand>().ReverseMap();

            CreateMap<UserRecycleProduct, DeletedUserRecycleProductDto>().ReverseMap();
            CreateMap<UserRecycleProduct, DeleteUserRecycleProductCommand>().ReverseMap();

            CreateMap<UserRecycleProduct, UpdatedUserRecycleProductDto>().ReverseMap();
            CreateMap<UserRecycleProduct, UpdateUserRecycleProductCommand>().ReverseMap();

            CreateMap<UserRecycleProduct, UserRecycleProductDto>()
                .ForMember(u => u.RecycleName, opt => opt.MapFrom(u => u.RecycleProduct.RecycleName))
                .ForMember(u => u.RecyclePoint, opt => opt.MapFrom(u => u.RecycleProduct.RecyclePoint))
                .ForMember(u => u.RecycleTypeId, opt => opt.MapFrom(u => u.RecycleProduct.RecycleTypeId))
                .ForMember(u => u.RecycleTypeName, opt => opt.MapFrom(u => u.RecycleProduct.RecycleType.RecycleTypeName))
                .ReverseMap();
            CreateMap<UserRecycleProduct, UserRecycleProductListDto>()
                .ForMember(u => u.RecycleName, opt => opt.MapFrom(u => u.RecycleProduct.RecycleName))
                .ForMember(u => u.RecyclePoint, opt => opt.MapFrom(u => u.RecycleProduct.RecyclePoint))
                .ForMember(u => u.RecycleTypeId, opt => opt.MapFrom(u => u.RecycleProduct.RecycleTypeId))
                .ForMember(u => u.RecycleTypeName, opt => opt.MapFrom(u => u.RecycleProduct.RecycleType.RecycleTypeName))
                .ReverseMap();
            CreateMap<IPaginate<UserRecycleProduct>, UserRecycleProductListModel>().ReverseMap();
        }
    }
}
