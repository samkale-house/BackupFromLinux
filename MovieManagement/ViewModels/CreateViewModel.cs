﻿using Microsoft.AspNetCore.Http;
using MovieManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title can not exceed 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Generes Genre { get; set; }
        [Required(ErrorMessage = "Price required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public IFormFile PhotoPath { get; set; }
    }
}
