using Core.Entities;

namespace Entities.Concrete
{
    public class RecycleType:Entity
    {
        public string RecycleTypeName { get; set; }

        public RecycleType()
        {

        }
        public RecycleType(int id, string recycleTypeName) :this()
        {
            Id= id;
            RecycleTypeName= recycleTypeName;
        }
    }
}
