namespace Business.Features.UserRecycleProducts.Dtos
{
    public class UserRecycleProductListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecycleProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }


        public string RecycleName { get; set; }
        public int RecyclePoint { get; set; }
        public int RecycleTypeId { get; set; }


        public string RecycleTypeName { get; set; }
    }

}
