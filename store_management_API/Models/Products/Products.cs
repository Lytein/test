using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_management_WebAPI;

public class Product
{
    [Key]
    public int product_id { get; set; }
    public int? category_id { get; set; }
    public int? supplier_id { get; set; }
    public string? product_name { get; set; }
    public string? barcode { get; set; }
    public decimal? price { get; set; }
    public string? unit { get; set; }
    public string? image_url { get; set; }
    public DateTime? created_at { get; set; }
    public Category? Category { get; set; }
    public Supplier? Supplier { get; set; }

    public Inventory? Inventory { get; set; }
    public ICollection<Order_item> Items { get; set; } = new List<Order_item>();

}

