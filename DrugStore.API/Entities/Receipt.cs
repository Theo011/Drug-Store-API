﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Date))]
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; private set; }
        public int CustomerId { get; private set; }

        public ICollection<ProductReceipt> ProductReceipt { get; private set; } = new List<ProductReceipt>();

        public Receipt(int id, DateTime date, string description, int customerId)
        {
            Id = id;
            Date = date;
            Description = description;
            CustomerId = customerId;
        }
    }
}