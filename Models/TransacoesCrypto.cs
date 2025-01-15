namespace cryptoPayment.Models
{
    public class TransacoesCrypto
    {
        public int Id { get; set; } // Chave primária
        public string TokenTransaction { get; set; }
        public string Cryptocurrency { get; set; }
        public double ValCrypto { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
    }
}
