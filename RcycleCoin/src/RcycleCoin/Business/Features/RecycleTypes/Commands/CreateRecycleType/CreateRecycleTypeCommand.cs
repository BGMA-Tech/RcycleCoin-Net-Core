using AutoMapper;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleTypes.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Commands.CreateRecycleType
{
    public class CreateRecycleTypeCommand:IRequest<CreatedRecycleTypeDto>//,ISecuredRequest
    {
        public string RecycleTypeName { get; set; }
        //public string[] Roles => new[] {Admin, RecycleTypeAdd};

        public class CreateRecycleTypeCommandHandler : IRequestHandler<CreateRecycleTypeCommand,CreatedRecycleTypeDto>
        {
            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;
            private readonly RecycleTypeBusinessRules _recycleTypeBusinessRules;

            public CreateRecycleTypeCommandHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper, RecycleTypeBusinessRules recycleTypeBusinessRules)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
                _recycleTypeBusinessRules = recycleTypeBusinessRules;
            }

            public async Task<CreatedRecycleTypeDto> Handle(CreateRecycleTypeCommand request, CancellationToken cancellationToken)
            {
                await _recycleTypeBusinessRules.RecycleTypeNameMustNotExist(request.RecycleTypeName);

                RecycleType mappedRecycleType = _mapper.Map<RecycleType>(request);
                RecycleType createdRecycleType = await _recycleTypeDal.AddAsync(mappedRecycleType);
                CreatedRecycleTypeDto createdRecycleTypeDto = _mapper.Map<CreatedRecycleTypeDto>(createdRecycleType);

                return createdRecycleTypeDto;
            }
        }
    }
}
