using Core.Utilities.JsonResults.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonResults.Abstract
{
    public class ErrorJsonDataResult<T> : JsonDataResult<T>
    {
        public ErrorJsonDataResult(T data, Error errorMessage) : base(data, false, errorMessage)
        {

        }
        public ErrorJsonDataResult(T data) : base(data, false)
        {

        }
        public ErrorJsonDataResult(Error errorMessage) : base(default, false, errorMessage)
        {

        }
        public ErrorJsonDataResult() : base(default, false)
        {

        }
    }
}
