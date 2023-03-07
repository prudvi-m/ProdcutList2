using System.ComponentModel.DataAnnotations;
namespace ProductList.Models
{
    public class Category
    {
        [Display(Name = "CategoryId")]
        [Required(ErrorMessage = "Please select category. child Model")]
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
