using Business.Features.UserRecycleProducts.Dtos;
using Core.DataAccess.EntityFramework.Paging;

namespace Business.Features.UserRecycleProducts.Models
{
    public class UserRecycleProductListModel:BasePageableModel
    {
        public IList<UserRecycleProductListDto> Items { get; set; }
    }
}
