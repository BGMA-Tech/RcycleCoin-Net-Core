using Core.JsonHelper;
using Core.JsonHelper.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Newtonsoft.Json;

namespace Core.Utilities.JsonResults.Concrete
{
    public class ConvertJsonDataResult<T>
    {
        public IDataResult<ResultDataJson<T>> JsonToData(string response)
        {
            JsonDataBeautify jsonDataBeautify = new JsonDataBeautify();
            ResultDataJson<T> result = JsonConvert.DeserializeObject<ResultDataJson<T>>(response);
            if (result.Status)
            {
                return new SuccessDataResult<ResultDataJson<T>>(result, JsonMessages.JsonDataFound);
            }
            return new ErrorDataResult<ResultDataJson<T>>(JsonMessages.JsonDataNotFound);
        }
    }
}
