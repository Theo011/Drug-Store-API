namespace DrugStore.API.Models
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set; }
    }
}