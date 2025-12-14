using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public class Order_item
{
    [Key]
    public int order_item_id { get; set; }
    public int? order_id { get; set; }
    public int? product_id { get; set; }
    public int? quanlity { get; set; }
    public decimal? price { get; set; }
    public decimal? subtotal { get; set; } = null;
}
