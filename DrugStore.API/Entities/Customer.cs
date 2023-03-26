using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Name), nameof(Ssn))]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; private set; }

        [Required]
        [MaxLength(5)]
        public string ZipCode { get; private set; }

        [Required]
        [MaxLength(9)]
        public string Ssn { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        [ForeignKey("InsurancesId")]
        public Insurance? Insurances { get; private set; }
        public int InsurancesId { get; private set; }

        public Customer(int id, string name, string address, string phone, string email, string zipCode, string ssn, string description, int insurancesId)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            ZipCode = zipCode;
            Ssn = ssn;
            Description = description;
            InsurancesId = insurancesId;
        }
    }
}