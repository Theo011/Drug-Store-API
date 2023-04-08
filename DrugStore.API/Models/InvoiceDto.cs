namespace DrugStore.API.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int SupplierId { get; set; }
    }
}