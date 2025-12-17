using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public enum OrderStatus
{
    pending,
    paid,
    canceled
}
public enum OrderType
{
    online,
    pos
}
public class Order
{
    [Key]
    public int order_id { get; set; }
    public int? customer_id { get; set; }
    public Customer? Customer { get; set; }
    public int? user_id { get; set; }
    public User? User { get; set; }
    public int? promo_id { get; set; }
    public Promotion? Promotion { get; set; }
    public OrderType order_type { get; set; } = OrderType.pos;
    public DateTime? order_date { get; set; }
    public decimal? total_amount { get; set; }
    public decimal? discount_amount { get; set; }
    public OrderStatus status { get; set; } = OrderStatus.pending;
    public ICollection<Order_item> Items { get; set; } = new List<Order_item>();
    public Payment? Payment { get; set; }
}