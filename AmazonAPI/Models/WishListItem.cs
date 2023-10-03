using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Repository;

namespace AmazonAPI.Models
{
    public class WishListItem : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        //navigation properties
        public ApplicationUser? Customer { get; set; }
        public Product? Product { get; set; }
    }
}