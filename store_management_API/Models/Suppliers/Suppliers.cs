using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace store_management_WebAPI;

public class Supplier
{
    [Key]
    public int supplier_id { get; set; }
    public string? name { get; set; }
    public string? phone { get; set; }
    public string? email { get; set; }
    public string? address { get; set; }
    [JsonIgnore]
    public ICollection<Product> Product { get; set; } = new List<Product>();

}