using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Repository;

namespace AmazonAPI.Models
{
    public class Review : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required, MaxLength(500, ErrorMessage = "Comment cannot be longer than 500 characters.")]
        public string Comment { get; set; }
        [Required, Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //navigation properties
        public ApplicationUser? Customer { get; set; }
        public Product? Product { get; set; }

    }
}