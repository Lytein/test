using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI.DTOs
{
    public class CustomerRegisterDto
    {
        [Required]
        [StringLength(100)]
        public string full_name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string email { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string phone { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string address { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string username { get; set; } = null!;

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string password { get; set; } = null!;
    }
}
