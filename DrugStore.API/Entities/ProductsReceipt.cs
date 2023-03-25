using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Keyless]
    [Index(nameof(Quantity))]
    public class ProductsReceipt
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("ReceiptsId")]
        public Invoices? Receipts { get; private set; }
        public int ReceiptsId { get; private set; }

        [ForeignKey("ProductsId")]
        public Products? Products { get; private set; }
        public int ProductsId { get; private set; }

        public ProductsReceipt(int quantity, string description, int receiptsId, int productsId)
        {
            Quantity = quantity;
            Description = description;
            ReceiptsId = receiptsId;
            ProductsId = productsId;
        }
    }
}