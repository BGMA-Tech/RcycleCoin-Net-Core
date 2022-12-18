using AutoMapper;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleTypes.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Commands.UpdateRecycleType
{
    public class UpdateRecycleTypeCommand:IRequest<UpdatedRecycleTypeDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string RecycleTypeName { get; set; }

        public string[] Roles => new[] { Admin, Personel, RecycleTypeDelete };

        public class UpdateRecycleTypeCommandHandler : IRequestHandler<UpdateRecycleTypeCommand, UpdatedRecycleTypeDto>
        {
            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;
            private readonly RecycleTypeBusinessRules _recycleTypeBusinessRules;

            public UpdateRecycleTypeCommandHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper, RecycleTypeBusinessRules recycleTypeBusinessRules)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
                _recycleTypeBusinessRules = recycleTypeBusinessRules;
            }

            public async Task<UpdatedRecycleTypeDto> Handle(UpdateRecycleTypeCommand request, CancellationToken cancellationToken)
            {
                await _recycleTypeBusinessRules.RecycleTypeIdMustBeAvailable(request.Id);

                RecycleType mappedRecycleType = _mapper.Map<RecycleType>(request);
                RecycleType updatedRecycleType = await _recycleTypeDal.UpdateAsync(mappedRecycleType);
                UpdatedRecycleTypeDto updatedRecycleTypeDto = _mapper.Map<UpdatedRecycleTypeDto>(updatedRecycleType);

                return updatedRecycleTypeDto;
            }
        }
    }
}
