using Core.Entities;

namespace Entities.Concrete
{
    public class UserRecycleProduct:Entity
    {
        public string UserId { get; set; }
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual RecycleProduct? RecycleProduct { get; set; }

        public UserRecycleProduct()
        {

        }

        public UserRecycleProduct(int id, string userId,int quantiy, int recycleProductId, DateTime createdAt) :this()
        {
            Id= id;
            UserId = userId;
            Quantity= quantiy;
            RecycleProductId = recycleProductId;
            CreatedAt = createdAt;
        }
    }
}
