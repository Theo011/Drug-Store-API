namespace DrugStore.API.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Ssn { get; set; } = null!;
        public string? Description { get; set; }
        public int InsuranceId { get; set; }
    }
}