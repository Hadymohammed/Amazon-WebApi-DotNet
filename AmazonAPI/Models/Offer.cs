using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Description { get; set; }
        [AllowNull]
        public double? Discount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        //navigation properties
        public List<Product>? Products { get; set; }

    }
}