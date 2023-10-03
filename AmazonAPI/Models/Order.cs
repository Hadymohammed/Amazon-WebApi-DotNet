using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data;
using AmazonAPI.Data.Repository;

namespace AmazonAPI.Models
{
    public class Order: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [AllowNull]
        public OrderStatus? CurrentStatus { get; set; }
        [AllowNull]
        public double? TotalPrice { get; set; }
        //navigation properties
        public ApplicationUser? Customer { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

    }
}