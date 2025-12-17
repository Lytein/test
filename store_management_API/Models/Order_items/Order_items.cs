using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace store_management_WebAPI;

public class Order_item
{
    [Key]
    public int order_item_id { get; set; }
    public int order_id { get; set; }
    public int product_id { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
    public decimal subtotal { get; set; }
    [JsonIgnore]
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
