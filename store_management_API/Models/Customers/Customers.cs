using store_management_WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace store_management_WebAPI;

public class Customer
{
    [Key]
    public int customer_id { get; set; } 
    public string? name { get; set; } 
    public string? phone { get; set; } 
    public string? email { get; set; }
    public string? address { get; set; }
    public DateTime created_at { get; set; } = DateTime.Now;
    [JsonIgnore]
    public CustomerAccount? Account { get; set; }
}
