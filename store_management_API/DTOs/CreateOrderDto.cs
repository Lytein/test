namespace store_management_WebAPI.DTOs
{
    public class CreateOrderDto
    {
        public int? customer_id { get; set; }
        public int? user_id { get; set; }
        public int? promo_id { get; set; }
        public OrderType order_type { get; set; }
        public List<CreateOrderItemDto> items { get; set; } = new();
    }
}
