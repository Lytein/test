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

        public DbSet<Order> Orders { get; set; }
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

            /* =======================
               USER
            ======================= */
            modelBuilder.Entity<User>()
                .Property(u => u.role)
                .HasConversion<string>();

            /* =======================
               CUSTOMER - ACCOUNT
            ======================= */
            modelBuilder.Entity<CustomerAccount>()
                .HasIndex(x => x.username)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Account)
                .WithOne(a => a.Customer)
                .HasForeignKey<CustomerAccount>(a => a.customer_id)
                .OnDelete(DeleteBehavior.Cascade);

            /* =======================
               CATEGORY - PRODUCT
            ======================= */
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.category_id)
                .OnDelete(DeleteBehavior.SetNull);


            /* =======================
               SUPPLIER - PRODUCT
            ======================= */
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Product)
                .HasForeignKey(p => p.supplier_id)
                .OnDelete(DeleteBehavior.SetNull);


            /* =======================
               PRODUCT - INVENTORY (1-1)
            ======================= */
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.product_id)
                .OnDelete(DeleteBehavior.Cascade);


            /* =======================
               ORDER
            ======================= */
            modelBuilder.Entity<Order>()
                .Property(o => o.status)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(o => o.order_type)
                .HasConversion<string>();

            // Order - Customer
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.customer_id)
                .OnDelete(DeleteBehavior.SetNull);

            // Order - User (staff/admin)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User) 
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.user_id)
                .OnDelete(DeleteBehavior.SetNull);

            // Order - Promotion
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Promotion)          
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.promo_id)
                .OnDelete(DeleteBehavior.SetNull);


            /* =======================
               ORDER - ORDER_ITEM
            ======================= */
            modelBuilder.Entity<Order_item>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.order_id)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Order_item>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(oi => oi.product_id)
                .OnDelete(DeleteBehavior.Restrict);

            /* =======================
               ORDER - PAYMENT (1-1)
            ======================= */
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.order_id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Payment>()
                .Property(p => p.payment_method)
                .HasConversion<string>();

            /* =======================
                Promotion 
                ======================= */
            modelBuilder.Entity<Promotion>()
                .Property(p => p.status)
                .HasConversion<string>();
        }

    }
}
