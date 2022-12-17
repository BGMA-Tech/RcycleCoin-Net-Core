namespace Core.Helper
{
    public class BaseHttpClient
    {
        public static string Token { get; set; }

        private static HttpClient _httpClient;
        private BaseHttpClient()
        {

        }
        public static HttpClient CreateHttpClient()
        {
            _httpClient = new HttpClient();
            if (Token != null && Token != "")
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
            }
            return _httpClient;
        }
    }
}
