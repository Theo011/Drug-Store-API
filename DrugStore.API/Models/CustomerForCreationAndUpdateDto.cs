﻿using System.ComponentModel.DataAnnotations;

namespace DrugStore.API.Models
{
    public class CustomerForCreationAndUpdateDto
    {
        [Required(ErrorMessage = "You need to provide a value for Name.")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for Address.")]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for Phone.")]
        [MaxLength(20)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for Email.")]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for ZipCode.")]
        [MaxLength(5)]
        public string ZipCode { get; set; } = null!;

        [Required(ErrorMessage = "You need to provide a value for Ssn.")]
        [MaxLength(9)]
        public string Ssn { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You need to provide a value for InsuranceId.")]
        public int InsuranceId { get; set; }
    }
}