using AutoMapper;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using MediatR;
using static Business.Features.UserRecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Commands.UpdateUserRecycleProduct
{
    public class UpdateUserRecycleProductCommand : IRequest<UpdatedUserRecycleProductDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }

        public string[] Roles => new[] {Admin, Personel, UserRecycleProductUpdate};

        public class UpdateUserRecycleProductCommandHanlder : IRequestHandler<UpdateUserRecycleProductCommand, UpdatedUserRecycleProductDto>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;
            private readonly UserRecycleProductBusinessRules _userRecycleProductBusinessRules;

            public UpdateUserRecycleProductCommandHanlder(IUserRecycleProductDal userRecycleProductDal, IMapper mapper, UserRecycleProductBusinessRules userRecycleProductBusinessRules)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
                _userRecycleProductBusinessRules = userRecycleProductBusinessRules;
            }

            public async Task<UpdatedUserRecycleProductDto> Handle(UpdateUserRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _userRecycleProductBusinessRules.UserRecycleProductIdMustBeAvailable(request.Id);
                if(request.RecycleProductId > 0)
                    await _userRecycleProductBusinessRules.RecycleProductIdMustBeAvailable(request.RecycleProductId);

                UserRecycleProduct mappedUserRecycleProduct = _mapper.Map<UserRecycleProduct>(request);
                if (request.UserId != null)
                {
                    mappedUserRecycleProduct.UserId = request.UserId;
                }
                UserRecycleProduct updatedUserRecycleProduct = await _userRecycleProductDal.UpdateAsync(mappedUserRecycleProduct);
                UpdatedUserRecycleProductDto updatedUserRecycleProductDto = _mapper.Map<UpdatedUserRecycleProductDto>(updatedUserRecycleProduct);

                return updatedUserRecycleProductDto;
            }
        }
    }
}
