using Business.Features.RecycleProducts.Dtos;
using Core.DataAccess.EntityFramework.Paging;

namespace Business.Features.RecycleProducts.Models
{
    public class RecycleProductListModel: BasePageableModel
    {
        public IList<RecycleProductListDto> Items { get; set; }
    }
}
