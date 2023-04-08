using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Quantity))]
    public class ProductReceipt
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("ReceiptId")]
        public Receipt? Receipt { get; private set; }
        public int ReceiptId { get; private set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; private set; }
        public int ProductId { get; private set; }

        public ProductReceipt(int quantity, string description, int receiptId, int productId)
        {
            Quantity = quantity;
            Description = description;
            ReceiptId = receiptId;
            ProductId = productId;
        }
    }
}