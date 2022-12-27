namespace Entities.Concrete
{
    public class RecycleProductImage:Entity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public RecycleProductImage()
        {

        }

        public RecycleProductImage(int id, string imagePath):this()
        {
            Id= id;
            ImagePath= imagePath;
        }
    }
}
