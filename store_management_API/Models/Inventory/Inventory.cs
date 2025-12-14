using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public class Inventory
{
    [Key]
    public int inventory_id { get; set; }
    public int? product_id { get; set; }
    public int? quanlity { get; set; }
    public DateTime updated_at { get; set; }
}
