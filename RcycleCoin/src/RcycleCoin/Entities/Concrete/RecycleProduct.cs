using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RecycleProduct:Entity
    {
        public string RecycleName { get; set; }
        public int RecyclePoint { get; set; }
        public int RecycleTypeId { get; set; }

        public virtual RecycleType RecycleType { get; set; }

        public RecycleProduct()
        {

        }

        public RecycleProduct(int id, string recycleName, int recyclePoint, int recycleTypeId):this()
        {
            Id= id;
            RecycleName = recycleName;
            RecyclePoint = recyclePoint;
            RecycleTypeId = recycleTypeId;
        }
    }
}
