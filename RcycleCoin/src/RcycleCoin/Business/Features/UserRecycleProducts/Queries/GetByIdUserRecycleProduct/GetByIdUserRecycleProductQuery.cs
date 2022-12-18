using AutoMapper;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Queries.GetByIdUserRecycleProduct
{
    public class GetByIdUserRecycleProductQuery:IRequest<UserRecycleProductDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetByIdUserRecycleProductQueryHandler : IRequestHandler<GetByIdUserRecycleProductQuery, UserRecycleProductDto>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;
            private readonly UserRecycleProductBusinessRules _userRecycleProductBusinessRules;

            public GetByIdUserRecycleProductQueryHandler(IUserRecycleProductDal userRecycleProductDal, IMapper mapper, UserRecycleProductBusinessRules userRecycleProductBusinessRules)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
                _userRecycleProductBusinessRules = userRecycleProductBusinessRules;
            }

            public async Task<UserRecycleProductDto> Handle(GetByIdUserRecycleProductQuery request, CancellationToken cancellationToken)
            {
                await _userRecycleProductBusinessRules.UserRecycleProductIdMustBeAvailable(request.Id);

                UserRecycleProduct? recycleProduct = await _userRecycleProductDal.GetAsync
                    (
                        r => r.Id == request.Id,
                        include: u => u.Include(u=> u.RecycleProduct).Include(u => u.RecycleProduct.RecycleType)
                    );
                UserRecycleProductDto userRecycleProductDto = _mapper.Map<UserRecycleProductDto>(recycleProduct);

                return userRecycleProductDto;
            }
        }
    }
}
