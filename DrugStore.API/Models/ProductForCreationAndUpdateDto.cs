using System.ComponentModel.DataAnnotations;

namespace DrugStore.API.Models
{
    public class ProductForCreationAndUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a value for Name.")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for PurchasePrice.")]
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "You need to provide a value for SalePrice.")]
        [DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You need to provide a value for CategoryId.")]
        public int CategoryId { get; set; }
    }
}