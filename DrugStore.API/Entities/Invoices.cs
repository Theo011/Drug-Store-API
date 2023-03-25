using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Date))]
    public class Invoices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("SuppliersId")]
        public Suppliers? Suppliers { get; private set; }
        public int SuppliersId { get; private set; }

        public Invoices(int id, DateTime date, string description, int suppliersId)
        {
            Id = id;
            Date = date;
            Description = description;
            SuppliersId = suppliersId;
        }
    }
}