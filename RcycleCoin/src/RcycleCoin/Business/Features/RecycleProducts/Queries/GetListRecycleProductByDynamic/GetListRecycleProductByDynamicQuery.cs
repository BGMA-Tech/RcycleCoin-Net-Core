using AutoMapper;
using Business.Features.RecycleProducts.Models;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Core.DataAccess.EntityFramework.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.RecycleProducts.Queries.GetListRecycleProductByDynamic
{
    public class GetListRecycleProductByDynamicQuery:IRequest<RecycleProductListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListRecycleProductByDynamicQueryHandler : IRequestHandler<GetListRecycleProductByDynamicQuery, RecycleProductListModel>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;

            public GetListRecycleProductByDynamicQueryHandler(IRecycleProductDal recycleProductDal, IMapper mapper)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
            }

            public async Task<RecycleProductListModel> Handle(GetListRecycleProductByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<RecycleProduct> recycleProducts = await _recycleProductDal.GetListByDynamicAsync
                    (
                        request.Dynamic,
                        include: d => d.Include(d => d.RecycleType),
                        request.PageRequest.Page,
                        request.PageRequest.PageSize
                    );
                RecycleProductListModel mappedRecycleProductListModel = _mapper.Map<RecycleProductListModel>(recycleProducts);
                return mappedRecycleProductListModel;
            }
        }
    }
}
