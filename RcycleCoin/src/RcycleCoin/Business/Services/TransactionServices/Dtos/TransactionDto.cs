namespace Business.Services.TransactionServices.Dtos
{
    public class TransactionDto
    {
        public string _id { get; set; }
        public string FromPersonelId { get; set; }
        public string ToPersonelId { get; set; }
        public int CoinAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
