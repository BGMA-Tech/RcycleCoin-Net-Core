using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonResults.Abstract
{
    public interface IJsonDataResult<T>
    {
        T Data { get; }
    }
}
