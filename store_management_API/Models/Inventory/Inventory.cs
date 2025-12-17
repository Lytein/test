using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace store_management_WebAPI;

public class Inventory
{
    [Key]
    public int inventory_id { get; set; }
    public int? product_id { get; set; }
    public int? quantity { get; set; }
    public DateTime updated_at { get; set; }
    public Product Product { get; set; } = null!;

}
