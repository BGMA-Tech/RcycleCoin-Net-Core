using AutoMapper;
using Business.Features.RecycleProducts.Models;
using Business.Features.RecycleProducts.Rules;
using Core.Application.Requests;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Core.DataAccess.EntityFramework.Paging;

namespace Business.Features.RecycleProducts.Queries.GetListRecycleProduct
{
    public class GetListRecycleProductQuery:IRequest<RecycleProductListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListRecycleProductQueryHanlder : IRequestHandler<GetListRecycleProductQuery, RecycleProductListModel>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;
            private readonly RecycleProductBusinessRules _recycleProductBusinessRules;

            public GetListRecycleProductQueryHanlder(IRecycleProductDal recycleProductDal, IMapper mapper, RecycleProductBusinessRules recycleProductBusinessRules)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
                _recycleProductBusinessRules = recycleProductBusinessRules;
            }

            public async Task<RecycleProductListModel> Handle(GetListRecycleProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<RecycleProduct> recycleProducts = await _recycleProductDal.GetListAsync
                    (
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );
                RecycleProductListModel mappedRecycleProductListModel = _mapper.Map<RecycleProductListModel>(recycleProducts);
                return mappedRecycleProductListModel;
            }
        }
    }
}
