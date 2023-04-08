using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Quantity))]
    public class ProductInvoice
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; private set; }
        public int InvoiceId { get; private set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; private set; }
        public int ProductId { get; private set; }

        public ProductInvoice(int quantity, string description, int invoiceId, int productId)
        {
            Quantity = quantity;
            Description = description;
            InvoiceId = invoiceId;
            ProductId = productId;
        }
    }
}