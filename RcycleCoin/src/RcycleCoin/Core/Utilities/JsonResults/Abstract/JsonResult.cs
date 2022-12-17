using Core.Utilities.JsonResults.Concrete;

namespace Core.Utilities.JsonResults.Abstract
{
    public class JsonResult:IJsonResult
    {
        public JsonResult(bool success, Error errorMessage) : this(success)
        {
            this.ErrorMessage = errorMessage;
        }
        public JsonResult(bool success)
        {
            this.Success = success;
        }
        public bool Success { get; }

        public Error ErrorMessage { get; }
    }
}
