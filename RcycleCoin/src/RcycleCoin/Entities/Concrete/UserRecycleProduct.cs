namespace Entities.Concrete
{
    public class UserRecycleProduct:Entity
    {
        public string UserId { get; set; }
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }

        public virtual RecycleProduct? RecycleProduct { get; set; }

        public UserRecycleProduct()
        {

        }

        public UserRecycleProduct(int id, string userId,int quantiy, int recycleProductId, DateTime createdAt, bool status) :this()
        {
            Id= id;
            UserId = userId;
            Quantity= quantiy;
            RecycleProductId = recycleProductId;
            CreatedAt = createdAt;
            Status = status;
        }
    }
}
