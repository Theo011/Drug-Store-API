namespace DrugStore.API.Models
{
    public class ProductReceiptDto
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int ReceiptId { get; set; }
        public int ProductId { get; set; }
    }
}