using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Quantity))]
    public class ProductInvoice
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("InvoicesId")]
        public Invoice? Invoices { get; private set; }
        public int InvoicesId { get; private set; }

        [ForeignKey("ProductsId")]
        public Product? Products { get; private set; }
        public int ProductsId { get; private set; }

        public ProductInvoice(int quantity, string description, int invoicesId, int productsId)
        {
            Quantity = quantity;
            Description = description;
            InvoicesId = invoicesId;
            ProductsId = productsId;
        }
    }
}