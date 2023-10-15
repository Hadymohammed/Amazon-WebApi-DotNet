using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Data.DTOs
{
    public class CreateStoreDTO
    {
        [Required]
        public string Name { get; set; }
        [Required, Url]
        public string LogoUrl { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, EmailAddress, Display(Name = "Business Email")]
        public string Email { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "Description must be less than 1000 characters")]
        public string Description { get; set; }
        [AllowNull, Url]
        public string? Website { get; set; }
    }
}