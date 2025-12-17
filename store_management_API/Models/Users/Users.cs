using System.ComponentModel.DataAnnotations;

namespace store_management_WebAPI;

public enum UserRole
{
    admin,
    staff
}
public class User
{
    [Key]
    public int user_id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public string? full_name { get; set; }
    public UserRole role { get; set; } = UserRole.staff;
    public DateTime? created_at { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

