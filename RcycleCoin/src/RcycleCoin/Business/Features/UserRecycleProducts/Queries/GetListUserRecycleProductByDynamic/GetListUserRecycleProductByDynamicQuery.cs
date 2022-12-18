using AutoMapper;
using Business.Features.UserRecycleProducts.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Dynamic;
using Core.DataAccess.EntityFramework.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Queries.GetListUserRecycleProductByDynamic
{
    public class GetListUserRecycleProductByDynamicQuery:IRequest<UserRecycleProductListModel>,ISecuredRequest
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetListUserRecycleProductByDynamicQueryHandler : IRequestHandler<GetListUserRecycleProductByDynamicQuery, UserRecycleProductListModel>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;

            public GetListUserRecycleProductByDynamicQueryHandler(IUserRecycleProductDal userRecycleProductDal, IMapper mapper)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
            }

            public async Task<UserRecycleProductListModel> Handle(GetListUserRecycleProductByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserRecycleProduct> userRecycleProducts = await _userRecycleProductDal.GetListByDynamicAsync
                    (
                        request.Dynamic,
                        include: d => d.Include(d => d.RecycleProduct),
                        request.PageRequest.Page,
                        request.PageRequest.PageSize
                    );
                UserRecycleProductListModel mappedUserRecycleProductList = _mapper.Map<UserRecycleProductListModel>(userRecycleProducts);
                return mappedUserRecycleProductList;
            }
        }
    }
}
