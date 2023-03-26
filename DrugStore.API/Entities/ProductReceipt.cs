using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Quantity))]
    public class ProductReceipt
    {
        [Required]
        public int Quantity { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("ReceiptsId")]
        public Receipt? Receipts { get; private set; }
        public int ReceiptsId { get; private set; }

        [ForeignKey("ProductsId")]
        public Product? Products { get; private set; }
        public int ProductsId { get; private set; }

        public ProductReceipt(int quantity, string description, int receiptsId, int productsId)
        {
            Quantity = quantity;
            Description = description;
            ReceiptsId = receiptsId;
            ProductsId = productsId;
        }
    }
}