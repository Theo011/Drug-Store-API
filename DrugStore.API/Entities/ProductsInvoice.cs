using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Keyless]
    [Index(nameof(Quantity))]
    public class ProductsInvoice
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("InvoicesId")]
        public Invoices? Invoices { get; private set; }
        public int InvoicesId { get; private set; }

        [ForeignKey("ProductsId")]
        public Products? Products { get; private set; }
        public int ProductsId { get; private set; }

        public ProductsInvoice(int quantity, string description, int invoicesId, int productsId)
        {
            Quantity = quantity;
            Description = description;
            InvoicesId = invoicesId;
            ProductsId = productsId;
        }
    }
}