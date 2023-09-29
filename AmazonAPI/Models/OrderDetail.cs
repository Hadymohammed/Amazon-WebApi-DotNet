using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data;

namespace AmazonAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [AllowNull]
        public OrderStatus? Status { get; set; }
        [AllowNull]
        public double? OriginalPricePerUnit { get; set; }
        [AllowNull]
        public double? PurshasePricePerUnit { get; set; }
        [AllowNull]
        public double? TotalPrice { get; set; }
        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        //navigation properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }

    }
}