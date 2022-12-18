using AutoMapper;
using Business.Features.RecycleTypes.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Core.DataAccess.EntityFramework.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Queries.GetListRecycleTypeByDynamic
{
    public class GetListRecycleTypeByDynamicQuery:IRequest<RecycleTypeListModel>,ISecuredRequest
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetListRecycleTypeByDynamicQueryHandler : IRequestHandler<GetListRecycleTypeByDynamicQuery, RecycleTypeListModel>
        {
            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;

            public GetListRecycleTypeByDynamicQueryHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
            }

            public async Task<RecycleTypeListModel> Handle(GetListRecycleTypeByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<RecycleType> recycleTypes = await _recycleTypeDal.GetListByDynamicAsync
                    (
                        request.Dynamic,
                        null,
                        request.PageRequest.Page,
                        request.PageRequest.PageSize
                    );
                RecycleTypeListModel mappedRecycleTypeListModel = _mapper.Map<RecycleTypeListModel>(recycleTypes);
                return mappedRecycleTypeListModel;
            }
        }
    }
}
