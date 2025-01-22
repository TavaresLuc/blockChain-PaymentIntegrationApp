
namespace cryptoPayment.Models;
public class CurrencyItem
{
    public string Name { get; set; }
    public string Asset { get; set; }
    public string ImageUrl { get; set; }
    public bool Maintenance { get; set; }

    public override string ToString() => Maintenance ? $"{Name} (Em manutenção)" : Name;


}

