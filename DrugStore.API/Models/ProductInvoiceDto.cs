namespace DrugStore.API.Models
{
    public class ProductInvoiceDto
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
    }
}