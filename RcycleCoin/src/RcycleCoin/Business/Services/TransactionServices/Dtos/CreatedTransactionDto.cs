namespace Business.Services.TransactionServices.Dtos
{
    public class CreatedTransactionDto
    {
        public string FromPersonelId { get; set; }
        public string ToPersonelId { get; set; }
        public int CoinAmount { get; set; }
    }
}
