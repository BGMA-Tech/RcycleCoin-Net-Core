using Core.Utilities.JsonResults.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonResults.Abstract
{
    public class SuccessJsonDataResult<T>:JsonDataResult<T>
    {
        public SuccessJsonDataResult(T data, Error errorMessage) : base(data, true, errorMessage)
        {

        }
        public SuccessJsonDataResult(T data) : base(data, true)
        {

        }
        public SuccessJsonDataResult(Error errorMessage) : base(default, true, errorMessage)
        {

        }
        public SuccessJsonDataResult() : base(default, true)
        {

        }
    }
}
