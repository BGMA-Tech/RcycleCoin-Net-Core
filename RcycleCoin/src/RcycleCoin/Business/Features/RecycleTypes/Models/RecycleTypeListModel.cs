using Business.Features.RecycleTypes.Dtos;
using Core.DataAccess.EntityFramework.Paging;

namespace Business.Features.RecycleTypes.Models
{
    public class RecycleTypeListModel:BasePageableModel
    {
        public IList<RecycleTypeListDto> Items { get; set; }
    }
}
