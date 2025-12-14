using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public enum OrderStatus
{
    pending,
    paid,
    canceled
}
public class Order
{
    [Key]
    public int order_id { get; set; }
    public int? customer_id { get; set; }
    public int? user_id { get; set; }
    public int? promo_id { get; set; }
    public DateTime? order_date { get; set; }
    public decimal? total_amount { get; set; }
    public decimal? discount_amount { get; set; }
    public OrderStatus status { get; set; } = OrderStatus.pending;

}