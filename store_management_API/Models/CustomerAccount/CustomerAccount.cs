using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_management_WebAPI.Models
{
    [Table("customer_accounts")]
    public class CustomerAccount
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int customer_id { get; set; }

        [Required]
        public string username { get; set; } = "";

        [Required]
        public string password { get; set; } = "";

        public DateTime created_at { get; set; } = DateTime.Now;

        [ForeignKey(nameof(customer_id))]
        public Customer Customer { get; set; } = null!;
    }
}
