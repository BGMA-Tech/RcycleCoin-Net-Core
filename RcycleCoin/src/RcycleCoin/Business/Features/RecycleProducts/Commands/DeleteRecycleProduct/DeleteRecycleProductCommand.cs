using AutoMapper;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleProducts.Commands.DeleteRecycleProduct
{
    public class DeleteRecycleProductCommand:IRequest<DeletedRecycleProductDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin,Personel, RecycleProductDelete };

        public class DeleteRecycleProductCommandHandler : IRequestHandler<DeleteRecycleProductCommand, DeletedRecycleProductDto>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;
            private readonly RecycleProductBusinessRules _recycleProductBusinessRules;

            public DeleteRecycleProductCommandHandler(IRecycleProductDal recycleProductDal, IMapper mapper, RecycleProductBusinessRules recycleProductBusinessRules)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
                _recycleProductBusinessRules = recycleProductBusinessRules;
            }

            public async Task<DeletedRecycleProductDto> Handle(DeleteRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _recycleProductBusinessRules.RecycleProductIdMustBeAvailable(request.Id);

                RecycleProduct mappedRecycleProduct = _mapper.Map<RecycleProduct>(request);
                RecycleProduct deletedRecycleProduct = await _recycleProductDal.DeleteAsync(mappedRecycleProduct);
                DeletedRecycleProductDto deletedRecycleProductDto = _mapper.Map<DeletedRecycleProductDto>(deletedRecycleProduct);

                return deletedRecycleProductDto;
            }
        }
    }
}
