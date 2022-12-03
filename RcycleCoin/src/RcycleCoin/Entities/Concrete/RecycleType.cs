using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
