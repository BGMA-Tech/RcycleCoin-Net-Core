using MongoDB.Bson;

namespace Business.Services.CoinServices.Dtos
{
    public class CoinDto
    {
        public string _id { get; set; }
        public string PersonelId { get; set; }
        public int TotalCoin { get; set; }
    }
}
