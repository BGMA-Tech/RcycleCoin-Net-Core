namespace Business.Features.RecycleProducts.Dtos
{
    public class UpdatedRecycleProductDto
    {
        public int Id { get; set; }
        public string RecycleName { get; set; }
        public int RecyclePoint { get; set; }
        public int RecycleTypeId { get; set; }
    }
}
