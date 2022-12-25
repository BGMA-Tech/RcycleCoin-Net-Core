using AutoMapper;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Constants;
using MediatR;
using static Business.Features.UserRecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Commands.CreateUserRecycleProduct
{
    public class CreateUserRecycleProductCommand : IRequest<CreatedUserRecycleProductDto>, ISecuredRequest
    {
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }

        public string[] Roles => new[] {Admin, Personel,UserRecycleProductAdd};

        public class CreateUserRecycleProductCommandHandler : IRequestHandler<CreateUserRecycleProductCommand, CreatedUserRecycleProductDto>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;
            private readonly UserRecycleProductBusinessRules _userRecycleProductBusinessRules;

            public CreateUserRecycleProductCommandHandler(IUserRecycleProductDal userRecycleProductDal, IMapper mapper, UserRecycleProductBusinessRules userRecycleProductBusinessRules)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
                _userRecycleProductBusinessRules = userRecycleProductBusinessRules;
            }

            public async Task<CreatedUserRecycleProductDto> Handle(CreateUserRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _userRecycleProductBusinessRules.RecycleProductIdMustBeAvailable(request.RecycleProductId);

                UserRecycleProduct mappedUserRecycleProduct = _mapper.Map<UserRecycleProduct>(request);
                mappedUserRecycleProduct.CreatedAt = Convert.ToDateTime(DateTime.Now.ToString("F"));
                mappedUserRecycleProduct.UserId = UserIdDto.UserId;
                mappedUserRecycleProduct.Status = false;
                UserRecycleProduct createdUserRecycleProduct = await _userRecycleProductDal.AddAsync(mappedUserRecycleProduct);
                CreatedUserRecycleProductDto createdUserRecycleProductDto = _mapper.Map<CreatedUserRecycleProductDto>(createdUserRecycleProduct);

                return createdUserRecycleProductDto;
            }
        }
    }
}
