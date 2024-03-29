﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugStore.API.Entities
{
    [Index(nameof(Name))]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        [MaxLength(500)]
        public string? Description { get; private set; }

        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}