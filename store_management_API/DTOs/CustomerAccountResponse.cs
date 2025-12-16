namespace store_management_WebAPI.DTOs
{
    public class CustomerAccountResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public CustomerResponse? Customer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
