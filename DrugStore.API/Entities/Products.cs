using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Name))]
    public class Products
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

        [ForeignKey("CategoriesId")]
        public Categories? Categories { get; private set; }
        public int CategoriesId { get; private set; }

        public Products(int id, string name, decimal purchasePrice, decimal salePrice, string description, int categoriesId)
        {
            Id = id;
            Name = name;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Description = description;
            CategoriesId = categoriesId;
        }
    }
}