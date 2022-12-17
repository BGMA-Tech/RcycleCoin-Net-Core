using Core.JsonHelper;
using Core.JsonHelper.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.JsonResults.Abstract;
using Newtonsoft.Json;

namespace Core.Utilities.JsonResults.Concrete
{
    public class ConvertJsonResult
    {
        //public IResult JsonResult(string responce)
        //{
        //    JsonDataBeautify jsonDataBeautify = new JsonDataBeautify();
        //    jsonDataBeautify.BeautifyJson(responce);
        //    ResultJson? result = JsonConvert.DeserializeObject<ResultJson>(responce);
        //    if (result.Success)
        //    {
        //        return new SuccessResult(result.ErrorMessage.Message);
        //    }
        //    return new ErrorResult(JsonMessages.JsonDataNotFound);
        //}
        public IResult JsonResult(string responce)
        {
            JsonDataBeautify jsonDataBeautify = new JsonDataBeautify();
            jsonDataBeautify.BeautifyJson(responce);
            ResultJson? result = JsonConvert.DeserializeObject<ResultJson>(responce);
            if (result.Success)
            {
                return new SuccessResult(result.Error.Message);
            }
            return new ErrorResult(JsonMessages.JsonDataNotFound);
        }
    }
}
