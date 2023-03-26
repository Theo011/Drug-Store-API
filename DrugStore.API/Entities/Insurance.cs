using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Name))]
    public class Insurance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        public Insurance(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}