using AutoMapper;
using Business.Features.RecycleTypes.Dtos;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Pipelines.Authorization;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Business.Features.RecycleTypes.Constants.OperationClaims;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Commands.DeleteRecycleType
{
    public class DeleteRecycleTypeCommand:IRequest<DeletedRecycleTypeDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] {Admin, Personel,RecycleTypeDelete};

        public class DeleteRecycleTypeCommandHandler : IRequestHandler<DeleteRecycleTypeCommand, DeletedRecycleTypeDto>
        {
            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;
            private readonly RecycleTypeBusinessRules _recycleTypeBusinessRules;

            public DeleteRecycleTypeCommandHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper, RecycleTypeBusinessRules recycleTypeBusinessRules)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
                _recycleTypeBusinessRules = recycleTypeBusinessRules;
            }

            public async Task<DeletedRecycleTypeDto> Handle(DeleteRecycleTypeCommand request, CancellationToken cancellationToken)
            {
                await _recycleTypeBusinessRules.RecycleTypeIdMustBeAvailable(request.Id);

                RecycleType mappedRecycleType = _mapper.Map<RecycleType>(request);
                RecycleType deletedRecycleType = await _recycleTypeDal.DeleteAsync(mappedRecycleType);
                DeletedRecycleTypeDto deletedRecycleTypeDto = _mapper.Map<DeletedRecycleTypeDto>(deletedRecycleType);

                return deletedRecycleTypeDto;
            }
        }
    }
}
