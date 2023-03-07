using System.ComponentModel.DataAnnotations;
using System;

namespace ProductList.Models
{
    public class Product
    {
        // EF Core will configure the database to generate this value
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Name.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a Description.")]
        public string Description { get; set; }

        public string? Code { get; set; } = "";

        public string? Price { get; set; } = "";

        public string? Vendor { get; set; } = "";
        
        [Range(1, 100000000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; } = 1;
        public Category Category { get; set; }

        [Range(1, 100000000, ErrorMessage = "Please select a warehouse.")]
        public int WarehouseId { get; set; } =
        public Warehouse Warehouse { get; set; }


        public int? Quantity { get; set; } = 0;

        public string Slug =>
            Description?.Replace(' ', '-').ToLower() + '-' + ProductName?.Replace(' ', '-').ToLower();
    }
}
