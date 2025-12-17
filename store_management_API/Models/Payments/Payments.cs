using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public enum PaymentMethod
{
    cash,
    card,
    bank_transfer,
    e_wallet
}
public class Payment
{
    [Key]
    public int payment_id { get; set; }
    public int? order_id { get; set; }
    public decimal? amount { get; set; }
    public PaymentMethod payment_method { get; set; } = PaymentMethod.cash;
    public DateTime? payment_date { get; set; }

    public Order Order { get; set; } = null!;
}

