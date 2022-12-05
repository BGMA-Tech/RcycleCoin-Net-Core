using AutoMapper;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Rules;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.RecycleProducts.Queries.GetByIdRecycleProduct
{
    public class GetByIdRecycleProductQuery:IRequest<RecycleProductDto>
    {
        public int Id { get; set; }

        public class GetByIdRecycleProductQueryHandler : IRequestHandler<GetByIdRecycleProductQuery, RecycleProductDto>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;
            private readonly RecycleProductBusinessRules _recycleProductBusinessRules;

            public GetByIdRecycleProductQueryHandler(IRecycleProductDal recycleProductDal, IMapper mapper, RecycleProductBusinessRules recycleProductBusinessRules)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
                _recycleProductBusinessRules = recycleProductBusinessRules;
            }

            public async Task<RecycleProductDto> Handle(GetByIdRecycleProductQuery request, CancellationToken cancellationToken)
            {
                await _recycleProductBusinessRules.RecycleProductIdMustBeAvailable(request.Id);

                RecycleProduct? recycleProduct = await _recycleProductDal.GetAsync
                    (
                        r => r.Id == request.Id,
                        include: r => r.Include(r => r.RecycleType)
                    );
                RecycleProductDto recycleProductDto = _mapper.Map<RecycleProductDto>(recycleProduct);

                return recycleProductDto;
            }
        }
    }
}
