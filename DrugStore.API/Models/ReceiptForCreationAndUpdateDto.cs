using System.ComponentModel.DataAnnotations;

namespace DrugStore.API.Models
{
    public class ReceiptForCreationAndUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a value for Date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You need to provide a value for CustomerId.")]
        public int CustomerId { get; set; }
    }
}