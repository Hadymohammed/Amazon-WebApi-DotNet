using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Models
{
    public class ProductPhoto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        [Required, Url]
        public string Url { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        //navigation properties
        public Product? Product { get; set; }

    }
}