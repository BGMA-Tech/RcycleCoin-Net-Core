﻿using AutoMapper;
using Business.Features.RecycleTypes.Models;
using Business.Features.RecycleTypes.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using static Entities.Constants.OperationClaims;

namespace Business.Features.RecycleTypes.Queries.GetListRecycleType
{
    public class GetListRecycleTypeQuery:IRequest<RecycleTypeListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetListRecycleTypeQueryHandler : IRequestHandler<GetListRecycleTypeQuery, RecycleTypeListModel>
        {

            private readonly IRecycleTypeDal _recycleTypeDal;
            private readonly IMapper _mapper;

            public GetListRecycleTypeQueryHandler(IRecycleTypeDal recycleTypeDal, IMapper mapper)
            {
                _recycleTypeDal = recycleTypeDal;
                _mapper = mapper;
            }

            public async Task<RecycleTypeListModel> Handle(GetListRecycleTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<RecycleType> recycleTypes = await _recycleTypeDal.GetListAsync
                    (
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );
                RecycleTypeListModel mappedRecycleTypeListModel = _mapper.Map<RecycleTypeListModel>(recycleTypes);
                return mappedRecycleTypeListModel;
            }
        }
    }
}
