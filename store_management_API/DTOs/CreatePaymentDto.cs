using store_management_WebAPI;

public class CreatePaymentDto
{
    public int order_id { get; set; }
    public PaymentMethod payment_method { get; set; }
}
