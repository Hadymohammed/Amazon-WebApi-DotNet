using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Models
{
    public class ProductTag
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Key cannot exceed 100 characters")]
        public string Key { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Value cannot exceed 100 characters")]
        public string Value { get; set; }
        public int ProductId { get; set; }
        //navigation properties
        public Product? Product { get; set; }

    }
}