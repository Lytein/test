using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public class Category
{
    [Key]
    public int category_id { get; set; }
    public string? category_name { get; set; }
}