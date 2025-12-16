using Microsoft.EntityFrameworkCore;
using store_management_WebAPI.Models;

namespace store_management_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /* =======================
           DbSet
        ======================= */

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<Order_item> Order_items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Payment> Payments { get; set; }

        /* =======================
           Fluent API
        ======================= */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* ===== USER ===== */
            modelBuilder.Entity<User>()
                .Property(u => u.role)
                .HasConversion<string>(); // enum -> string

            /* ===== CUSTOMER ACCOUNT ===== */

            // username unique
            modelBuilder.Entity<CustomerAccount>()
                .HasIndex(x => x.username)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Account)
                .WithOne(a => a.Customer)
                .HasForeignKey<CustomerAccount>(a => a.customer_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
