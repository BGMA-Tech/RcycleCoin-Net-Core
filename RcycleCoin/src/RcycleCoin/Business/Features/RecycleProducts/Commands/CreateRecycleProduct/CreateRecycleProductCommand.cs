using AutoMapper;
using Business.Features.RecycleProducts.Dtos;
using Business.Features.RecycleProducts.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Helper.FileHelpers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleProducts.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;


namespace Business.Features.RecycleProducts.Commands.CreateRecycleProduct
{
    public class CreateRecycleProductCommand : IRequest<CreatedRecycleProductDto>, ISecuredRequest
    {
        public string RecycleName { get; set; }
        public int RecyclePoint { get; set; }
        public int RecycleTypeId { get; set; }

        public string[] Roles => new[] {Admin, RecycleProductAdd,"Personel"};

        public class CreateRecycleProductCommandHandler : IRequestHandler<CreateRecycleProductCommand, CreatedRecycleProductDto>
        {
            private readonly IRecycleProductDal _recycleProductDal;
            private readonly IMapper _mapper;
            private readonly RecycleProductBusinessRules _recycleProductBusinessRules;

            public CreateRecycleProductCommandHandler(IRecycleProductDal recycleProductDal, IMapper mapper, RecycleProductBusinessRules recycleProductBusinessRules)
            {
                _recycleProductDal = recycleProductDal;
                _mapper = mapper;
                _recycleProductBusinessRules = recycleProductBusinessRules;
            }

            public async Task<CreatedRecycleProductDto> Handle(CreateRecycleProductCommand request, CancellationToken cancellationToken)
            {
                await _recycleProductBusinessRules.RecycleTypeIdMustBeAvailable(request.RecycleTypeId);
                await _recycleProductBusinessRules.RecycleProductNameMustNotExist(request.RecycleName);

                RecycleProduct mappedRecycleProduct = _mapper.Map<RecycleProduct>(request);
                RecycleProduct createdRecycleProduct = await _recycleProductDal.AddAsync(mappedRecycleProduct);
                CreatedRecycleProductDto createdRecycleProductDto = _mapper.Map<CreatedRecycleProductDto>(createdRecycleProduct);

                return createdRecycleProductDto;
            }
        }
    }
}
