using store_management_WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace store_management_WebAPI;

public class Category
{
    [Key]
    public int category_id { get; set; }
    public string? category_name { get; set; }
    [JsonIgnore]
    public ICollection<Product> Product { get; set; } = new List<Product>();

}