using Application.Mocks.Repositories;
using AutoMapper;
using Business.Features.RecycleTypes.Commands.CreateRecycleType;
using Business.Features.RecycleTypes.Commands.DeleteRecycleType;
using Business.Features.RecycleTypes.Commands.UpdateRecycleType;
using Business.Features.RecycleTypes.Profiles;
using Business.Features.RecycleTypes.Queries.GetByIdRecycleType;
using Business.Features.RecycleTypes.Queries.GetListRecycleType;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Moq;
using Xunit;
using static Business.Features.RecycleTypes.Commands.CreateRecycleType.CreateRecycleTypeCommand;
using static Business.Features.RecycleTypes.Commands.DeleteRecycleType.DeleteRecycleTypeCommand;
using static Business.Features.RecycleTypes.Commands.UpdateRecycleType.UpdateRecycleTypeCommand;
using static Business.Features.RecycleTypes.Queries.GetByIdRecycleType.GetByIdRecycleTypeQuery;
using static Business.Features.RecycleTypes.Queries.GetListRecycleType.GetListRecycleTypeQuery;

namespace Application.FeaturesTests.RecycleTypes
{
    public class RecycleTypeTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRecycleTypeDal> _mockRecycleTypeDal;
        private readonly RecycleTypeBusinessRules _recycleTypeBusinessRules;

        public RecycleTypeTests()
        {
            _mockRecycleTypeDal = new RecycleTypeMockRepository().GetRepository();

            _recycleTypeBusinessRules = new RecycleTypeBusinessRules(_mockRecycleTypeDal.Object);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AddRecycleTypeNotDuplicated()
        {
            CreateRecycleTypeCommandHandler handler = new CreateRecycleTypeCommandHandler(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            CreateRecycleTypeCommand command = new CreateRecycleTypeCommand();
            command.RecycleTypeName = "Demir";

            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal("Demir", result.RecycleTypeName);
        }

        [Fact]
        public async Task AddRecycleTypeWhenDuplicated()
        {
            CreateRecycleTypeCommandHandler handler = new CreateRecycleTypeCommandHandler(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            CreateRecycleTypeCommand command = new CreateRecycleTypeCommand();
            command.RecycleTypeName = "Pil";

           await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command,CancellationToken.None));
        }

        [Fact]
        public async Task UpdateRecycleTypeExistsRecycleType()
        {
            UpdateRecycleTypeCommandHandler handler = new(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            UpdateRecycleTypeCommand command = new UpdateRecycleTypeCommand();
            command.Id = 1;
            command.RecycleTypeName = "Plastik";

            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal("Plastik", result.RecycleTypeName);
        }

        [Fact]
        public async Task UpdateRecycleTypeWhenNotExistsRecycleType()
        {
            UpdateRecycleTypeCommandHandler handler = new(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            UpdateRecycleTypeCommand command = new UpdateRecycleTypeCommand();
            command.Id = 8;
            command.RecycleTypeName = "Plastik";

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command,CancellationToken.None));
        }


        [Fact]
        public async Task DeleteRecycleTypeWhenExistsRecycleType()
        {
            DeleteRecycleTypeCommandHandler handler = new(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            DeleteRecycleTypeCommand command = new DeleteRecycleTypeCommand();
            command.Id = 1;

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteRecycleTypeWhenNotExistsRecycleType()
        {
            DeleteRecycleTypeCommandHandler handler = new(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            DeleteRecycleTypeCommand command = new DeleteRecycleTypeCommand();
            command.Id = 8;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task GetAllRecycleType()
        {
            GetListRecycleTypeQueryHandler handler = new GetListRecycleTypeQueryHandler(_mockRecycleTypeDal.Object, _mapper);
            GetListRecycleTypeQuery query = new GetListRecycleTypeQuery();
            query.PageRequest = new PageRequest
            {
                Page = 0,
                PageSize = 4
            };

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.Equal(4, result.Items.Count);
        }

        [Fact]
        public async Task GetByIdRecycleTypeWhenExistsRecycleType()
        {
            GetByIdRecycleTypeQueryHandler handler = new GetByIdRecycleTypeQueryHandler(_mockRecycleTypeDal.Object, _mapper,_recycleTypeBusinessRules);
            GetByIdRecycleTypeQuery query = new GetByIdRecycleTypeQuery();
            query.Id = 1;

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.Equal("Şişe", result.RecycleTypeName);
        }

        [Fact]
        public async Task GetByIdRecycleTypeWhenNotExistsRecycleType()
        {
            GetByIdRecycleTypeQueryHandler handler = new GetByIdRecycleTypeQueryHandler(_mockRecycleTypeDal.Object, _mapper, _recycleTypeBusinessRules);
            GetByIdRecycleTypeQuery query = new GetByIdRecycleTypeQuery();
            query.Id = 6;

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}
