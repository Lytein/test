using System.ComponentModel.DataAnnotations;

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
    public DateTime? created_at { get; set; }
}

