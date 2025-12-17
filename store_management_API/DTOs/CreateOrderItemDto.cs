namespace store_management_WebAPI.DTOs
{
    public class CreateOrderItemDto
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
