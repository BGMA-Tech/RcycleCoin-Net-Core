using Core.Utilities.Abstract;
using Core.Utilities.JsonResults.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonResults.Abstract
{
    public class JsonDataResult<T> : JsonResult, IJsonDataResult<T>
    {
        public T Data { get; set; }
        public bool Status { get; set; }

        public JsonDataResult(T data, bool success) : base(success)
        {
            this.Data = data;
        }

        public JsonDataResult(T data, bool success, Error errorMessage) : base(success, errorMessage)
        {
            this.Data = data;
        }
    }
}
