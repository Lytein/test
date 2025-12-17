using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public enum PromotionStatus
{
    active,
    inactive
}
public class Promotion
{
    [Key]
    public int promo_id { get; set; }
    public string? promo_code { get; set; }
    public string? description { get; set; }
    public string? discount_type { get; set; }
    public decimal? discount_value { get; set; }
    public DateTime? start_date { get; set; }
    public DateTime? end_date { get; set; }
    public decimal? min_order_amount { get; set; }
    public int? usage_limit { get; set; }
    public int? used_count { get; set; }
    public string? status { get; set; } = PromotionStatus.active.ToString();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

