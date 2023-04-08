using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Date))]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; private set; }
        public int SupplierId { get; private set; }

        public ICollection<ProductInvoice> ProductInvoice { get; private set; } = new List<ProductInvoice>();

        public Invoice(int id, DateTime date, string description, int supplierId)
        {
            Id = id;
            Date = date;
            Description = description;
            SupplierId = supplierId;
        }
    }
}