using AutoMapper;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Queries.GetByIdRecycleType
{
    public class GetByIdRecycleTypeQuery:IRequest<RecycleTypeDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetByIdRecycleTypeQueryHandler : IRequestHandler<GetByIdRecycleTypeQuery, RecycleTypeDto>
        {
            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;
            private readonly RecycleTypeBusinessRules _recycleTypeBusinessRules;

            public GetByIdRecycleTypeQueryHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper, RecycleTypeBusinessRules recycleTypeBusinessRules)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
                _recycleTypeBusinessRules = recycleTypeBusinessRules;
            }

            public async Task<RecycleTypeDto> Handle(GetByIdRecycleTypeQuery request, CancellationToken cancellationToken)
            {
                await _recycleTypeBusinessRules.RecycleTypeIdMustBeAvailable(request.Id);

                RecycleType? recycleType = await _recycleTypeDal.GetAsync(r => r.Id == request.Id);
                RecycleTypeDto recycleTypeDto = _mapper.Map<RecycleTypeDto>(recycleType);

                return recycleTypeDto;
            }
        }
    }
}
