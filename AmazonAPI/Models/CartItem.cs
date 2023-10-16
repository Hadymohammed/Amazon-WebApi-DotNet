using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Repository;

namespace AmazonAPI.Models
{
    public class CartItem : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [AllowNull]
        public double? TotalPrice { get; set; }
        //navigation properties
        public ApplicationUser? Customer { get; set; }
        public Product? Product { get; set; }
    }
}