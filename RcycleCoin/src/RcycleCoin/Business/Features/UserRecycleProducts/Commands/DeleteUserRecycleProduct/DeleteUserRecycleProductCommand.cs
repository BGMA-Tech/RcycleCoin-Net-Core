using AutoMapper;
using Business.Features.UserRecycleProducts.Dtos;
using Business.Features.UserRecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.UserRecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Commands.DeleteUserRecycleProduct
{
    public class DeleteUserRecycleProductCommand : IRequest<DeletedUserRecycleProductDto>//, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] {Admin, UserRecycleProductDelete};

        public class DeleteUserRecycleProductCommandHanlder : IRequestHandler<DeleteUserRecycleProductCommand, DeletedUserRecycleProductDto>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;
            private readonly UserRecycleProductBusinessRules _userRecycleProductBusinessRules;

            public DeleteUserRecycleProductCommandHanlder(IUserRecycleProductDal userRecycleProductDal, IMapper mapper, UserRecycleProductBusinessRules userRecycleProductBusinessRules)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
                _userRecycleProductBusinessRules = userRecycleProductBusinessRules;
            }

            public async Task<DeletedUserRecycleProductDto> Handle(DeleteUserRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _userRecycleProductBusinessRules.UserRecycleProductIdMustBeAvailable(request.Id);

                UserRecycleProduct mappedUserRecycleProduct = _mapper.Map<UserRecycleProduct>(request);
                UserRecycleProduct deletedUserRecycleProduct = await _userRecycleProductDal.DeleteAsync(mappedUserRecycleProduct);
                DeletedUserRecycleProductDto deletedUserRecycleProductDto = _mapper.Map<DeletedUserRecycleProductDto>(deletedUserRecycleProduct);

                return deletedUserRecycleProductDto;
            }
        }
    }
}
