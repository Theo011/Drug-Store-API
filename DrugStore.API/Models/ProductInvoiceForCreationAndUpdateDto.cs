using System.ComponentModel.DataAnnotations;

namespace DrugStore.API.Models
{
    public class ProductInvoiceForCreationAndUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a value for Quantity.")]
        public int Quantity { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You need to provide a value for InvoiceId.")]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "You need to provide a value for ProductId.")]
        public int ProductId { get; set; }
    }
}