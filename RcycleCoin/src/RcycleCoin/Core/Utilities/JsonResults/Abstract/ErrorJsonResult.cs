using Core.Utilities.JsonResults.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonResults.Abstract
{
    public class ErrorJsonResult : JsonResult
    {
        public ErrorJsonResult() : base(false)
        {

        }
        public ErrorJsonResult(Error errorMessage) : base(false, errorMessage)
        {
        }
    }
}
