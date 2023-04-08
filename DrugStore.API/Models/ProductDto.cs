namespace DrugStore.API.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}