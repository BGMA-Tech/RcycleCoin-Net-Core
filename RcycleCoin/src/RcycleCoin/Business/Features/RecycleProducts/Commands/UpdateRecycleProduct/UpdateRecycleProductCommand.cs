using AutoMapper;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleProducts.Commands.UpdateRecycleProduct
{
    public class UpdateRecycleProductCommand : IRequest<UpdatedRecycleProductDto>//, ISecuredRequest
    {
        public int Id { get; set; }
        public string RecycleName { get; set; }
        public int RecyclePoint { get; set; }
        public int RecycleTypeId { get; set; }

        public string[] Roles => new[] {Admin, RecycleProductUpdate};

        public class UpdateRecycleProductCommandHandler : IRequestHandler<UpdateRecycleProductCommand, UpdatedRecycleProductDto>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;
            private readonly RecycleProductBusinessRules _recycleProductBusinessRules;

            public UpdateRecycleProductCommandHandler(IRecycleProductDal recycleProductDal, IMapper mapper, RecycleProductBusinessRules recycleProductBusinessRules)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
                _recycleProductBusinessRules = recycleProductBusinessRules;
            }

            public async Task<UpdatedRecycleProductDto> Handle(UpdateRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _recycleProductBusinessRules.RecycleProductIdMustBeAvailable(request.Id);
                if(request.RecycleTypeId > 0)
                    await _recycleProductBusinessRules.RecycleTypeIdMustBeAvailable(request.RecycleTypeId);

                RecycleProduct mappedRecycleProduct = _mapper.Map<RecycleProduct>(request);
                RecycleProduct updatedRecycleProduct = await _recycleProductDal.UpdateAsync(mappedRecycleProduct);
                UpdatedRecycleProductDto updatedRecycleProductDto = _mapper.Map<UpdatedRecycleProductDto>(updatedRecycleProduct);

                return updatedRecycleProductDto;
            }
        }
    }
}
