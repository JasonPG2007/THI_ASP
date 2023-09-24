using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop MSI 2022", Price = 3000.00, Quantity = 200 },
                new Product { ProductId = 2, Name = "Laptop ACER 2023", Price = 2500.00, Quantity = 220 },
                new Product { ProductId = 3, Name = "Laptop ASUS 2022", Price = 2700.00, Quantity = 220 },
                new Product { ProductId = 4, Name = "Laptop DELL 2022", Price = 3900.00, Quantity = 220 },
                new Product { ProductId = 5, Name = "Laptop HP 2021", Price = 1900.00, Quantity = 220 },
                new Product { ProductId = 6, Name = "Laptop MSI 2023", Price = 4000.00, Quantity = 220 }
                );
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Ngô Văn Lợi" },
                new Customer { CustomerId = 2, Name = "Hoàng Văng Tấn" },
                new Customer { CustomerId = 3, Name = "Đào Hải Nam" },
                new Customer { CustomerId = 4, Name = "Trần Thị Huyền" },
                new Customer { CustomerId = 5, Name = "Nguyễn Văn Lực" }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ProductId = 1, CustomerId = 3, CreatedDate = "2023 - 07 - 01" },
                new Order { OrderId = 2, ProductId = 5, CustomerId = 2, CreatedDate = "2023 - 07 - 01" },
                new Order { OrderId = 3, ProductId = 4, CustomerId = 2, CreatedDate = "2023 - 07 - 01" },
                new Order { OrderId = 4, ProductId = 3, CustomerId = 1, CreatedDate = "2023 - 06 - 30" },
                new Order { OrderId = 5, ProductId = 2, CustomerId = 1, CreatedDate = "2023 - 06 - 30" },
                new Order { OrderId = 6, ProductId = 1, CustomerId = 1, CreatedDate = "2023 - 06 - 30" }
                );

        }
    }
}
