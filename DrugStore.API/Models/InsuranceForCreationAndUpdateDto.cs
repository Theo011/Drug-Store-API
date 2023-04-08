using System.ComponentModel.DataAnnotations;

namespace DrugStore.API.Models
{
    public class InsuranceForCreationAndUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a value for Name.")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}