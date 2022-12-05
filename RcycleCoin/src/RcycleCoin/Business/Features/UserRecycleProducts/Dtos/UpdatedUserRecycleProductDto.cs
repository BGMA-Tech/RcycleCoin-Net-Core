namespace Business.Features.UserRecycleProducts.Dtos
{
    public class UpdatedUserRecycleProductDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }
    }

}
