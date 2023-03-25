using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Date))]
    public class Receipts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("CustomersId")]
        public Customers? Customers { get; private set; }
        public int CustomersId { get; private set; }

        public Receipts(int id, DateTime date, string description, int customersId)
        {
            Id = id;
            Date = date;
            Description = description;
            CustomersId = customersId;
        }
    }
}