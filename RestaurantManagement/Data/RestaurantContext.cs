using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data.Domain;

namespace ReastaurantManagement.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuPosition> MenuPositions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInMenuPosition> ProductInMenuPositions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public RestaurantContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(2000)
                    .HasColumnName("first_name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(2000)
                    .HasColumnName("surname");

                entity.Property(e => e.Login)
                    .HasColumnName("login");

                entity.Property(e => e.Email)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasColumnName("password");

                entity.HasOne(e => e.Role)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.Employee);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.Customer);
            });

            modelBuilder.Entity<MenuPosition>(entity =>
            {
                entity.ToTable("menu_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnName("price");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date");

                entity.Property(e => e.IsPayed)
                    .HasColumnName("is_payed");

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<OrderPosition>(entity =>
            {
                entity.ToTable("order_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.OrderPositions)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.MenuPosition)
                    .WithMany(e => e.OrderPositions)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnName("price");

                entity.Property(e => e.Count)
                    .HasColumnName("count");
            });

            modelBuilder.Entity<ProductInMenuPosition>(entity =>
            {
                entity.ToTable("product_in_menu_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.ProductInMenuPositions)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.MenuPosition)
                    .WithMany(e => e.ProductInMenuPositions)
                    .HasForeignKey(e => e.MenuPositionId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bills");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount");

                entity.HasOne(e => e.Order)
                    .WithMany(e => e.Bills)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
