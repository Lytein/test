using Microsoft.EntityFrameworkCore;

namespace store_management_WebAPI.Data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.role)
            .HasConversion<string>(); // lưu enum dưới dạng string
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Order_item> Order_items { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Payment> Payments { get; set; }
}
