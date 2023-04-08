using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Name))]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; private set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal SalePrice { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; private set; }
        public int CategoryId { get; private set; }

        public ICollection<ProductInvoice> ProductInvoice { get; private set; } = new List<ProductInvoice>();
        public ICollection<ProductReceipt> ProductReceipt { get; private set; } = new List<ProductReceipt>();

        public Product(int id, string name, decimal purchasePrice, decimal salePrice, string description, int categoryId)
        {
            Id = id;
            Name = name;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Description = description;
            CategoryId = categoryId;
        }
    }
}