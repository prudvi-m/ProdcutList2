using System.ComponentModel.DataAnnotations;
namespace ProductList.Models
{
    public class Warehouse
    {
        [Display(Name = "WarehouseId")]
        [Required(ErrorMessage = "Please select Warehouse.")]
        public int WarehouseId { get; set; }
        public string Name { get; set; }
    }
}
