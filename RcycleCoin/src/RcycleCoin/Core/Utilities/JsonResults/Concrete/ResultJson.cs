using Newtonsoft.Json;

namespace Core.Utilities.JsonResults.Concrete
{
    public class ResultJson
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
    }
}
