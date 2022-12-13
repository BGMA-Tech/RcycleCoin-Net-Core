using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.JsonHelper
{
    public class JsonDataBeautify
    {
        public string BeautifyJson(string json)
        {
            JToken parseJson = JToken.Parse(json);
            return parseJson.ToString(Formatting.Indented);
        }
    }
}
