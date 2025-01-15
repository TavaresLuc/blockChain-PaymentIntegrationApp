namespace cryptoPayment.Models;

public class TransacaoResponse
{
    public int Status { get; set; }
    public TransacaoData Resp { get; set; }
}

public class TransacaoData
{
    public string Cryptocurrency { get; set; }
    public double ValCrypto { get; set; }
    public string Address { get; set; }
    public string TokenTransaction { get; set; }
    public string QrCode { get; set; }
}
