namespace Business.Services.TransactionServices.Dtos
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public string FromPersonelId { get; set; }
        public string ToPersonelId { get; set; }
        public int CoinAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
