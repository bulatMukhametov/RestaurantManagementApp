using Microsoft.EntityFrameworkCore;
using WebApplication4.Data.Domain;

namespace WebApplication4.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuPosition> MenuPositions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInMenuPosition> ProductInMenuPositions { get; set; }

        public RestaurantContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=RestaurantManagement.db");
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

                entity.Property(x => x.Surname)
                    .HasMaxLength(2000)
                    .HasColumnName("surname");

                entity.Property(x => x.Login)
                    .HasColumnName("login");

                entity.Property(x => x.Email)
                    .HasColumnName("email");

                entity.Property(x => x.Password)
                    .HasColumnName("password");

                entity.HasOne(x=> x.Role)
                    .WithMany(x=> x.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<MenuPosition>(entity =>
            {
                entity.ToTable("menu_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .HasColumnName("name");

                entity.Property(x=> x.Price)
                    .HasColumnName("price");

                entity.Property(x=> x.IsActive)
                    .HasColumnName("is_active");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<OrderPosition>(entity =>
            {
                entity.ToTable("order_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPositions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.MenuPosition)
                    .WithMany(p => p.OrderPositions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .HasColumnName("name");

                entity.Property(x => x.Price)
                    .HasColumnName("price");

                entity.Property(x => x.Count)
                    .HasColumnName("count");
            });

            modelBuilder.Entity<ProductInMenuPosition>(entity =>
            {
                entity.ToTable("product_in_menu_positions");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInMenuPositions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.MenuPosition)
                    .WithMany(p => p.ProductInMenuPositions)
                    .HasForeignKey(d => d.MenuPositionId)
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

        }
    }
}
