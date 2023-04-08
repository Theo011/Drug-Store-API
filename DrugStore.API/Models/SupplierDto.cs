﻿namespace DrugStore.API.Models
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Ein { get; set; } = null!;
        public string? Description { get; set; }
    }
}