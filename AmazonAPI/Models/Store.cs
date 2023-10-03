using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Repository;

namespace AmazonAPI.Models
{
    public class Store : IEntityBase
    {
        [Key]
        public int Id { get; set; }
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
        [AllowNull, DefaultValue(false)]
        public bool? IsApporved { get; set; }
        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public ApplicationUser? Owner { get; set; }
        public List<Product>? Products { get; set; }
    }
}