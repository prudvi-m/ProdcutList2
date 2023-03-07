using Microsoft.EntityFrameworkCore;

namespace ProductList.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Clothing" },
                new Category { CategoryId = 2, Name = "Food" },
                new Category { CategoryId = 3, Name = "Grocery" },
                new Category { CategoryId = 4, Name = "Electronics" },
                new Category { CategoryId = 5, Name = "Home" },
                new Category { CategoryId = 6, Name = "Garden" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Warehouse { WarehouseId = 1, Name = "Chicago" },
                new Warehouse { WarehouseId = 2, Name = "New York" },
                new Warehouse { WarehouseId = 3, Name = "San Francisco" },
                new Warehouse { WarehouseId = 4, Name = "Miami" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Description = "Clothing",
                    ProductName = "Us polo T-shirt",
                    Code = "555-987-6543",
                    Vendor = "amazon@hotmail.com",
                    CategoryId = 1,
                    WarehouseId = 1
                },
                new Product
                {
                    ProductId = 1,
                    Description = "Pantry",
                    ProductName = "Vanilla Ice Cream",
                    Code = "555-987-6543",
                    Vendor = "amazon@hotmail.com",
                    CategoryId = 2,
                    WarehouseId = 2
                }
            );
        }
    }
}
