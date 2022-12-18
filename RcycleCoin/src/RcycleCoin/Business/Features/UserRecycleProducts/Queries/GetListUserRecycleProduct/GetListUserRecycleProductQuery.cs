using AutoMapper;
using Business.Features.UserRecycleProducts.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.DataAccess.EntityFramework.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Entities.Constants.OperationClaims;

namespace Business.Features.UserRecycleProducts.Queries.GetListUserRecycleProduct
{
    public class GetListUserRecycleProductQuery:IRequest<UserRecycleProductListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { Admin, Personel };

        public class GetListUserRecycleProductQueryHandler : IRequestHandler<GetListUserRecycleProductQuery, UserRecycleProductListModel>
        {
            private readonly IUserRecycleProductDal _userRecycleProductDal;
            private readonly IMapper _mapper;

            public GetListUserRecycleProductQueryHandler(IUserRecycleProductDal userRecycleProductDal, IMapper mapper)
            {
                _userRecycleProductDal = userRecycleProductDal;
                _mapper = mapper;
            }

            public async Task<UserRecycleProductListModel> Handle(GetListUserRecycleProductQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserRecycleProduct> userRecycleProducts = await _userRecycleProductDal.GetListAsync
                    (
                        include: u => u.Include(u => u.RecycleProduct).Include(u => u.RecycleProduct.RecycleType),
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );
                UserRecycleProductListModel mappedUserRecycleProductListModel = _mapper.Map<UserRecycleProductListModel>(userRecycleProducts);
                return mappedUserRecycleProductListModel;
            }
        }
    }
}
