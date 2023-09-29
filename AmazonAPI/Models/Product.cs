using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [AllowNull]
        public double? Rating { get; set; }
        [Required, ForeignKey("Store")]
        public int StoreId { get; set; }
        [AllowNull, ForeignKey("Offer")]
        public int? OfferId { get; set; }
        //navigation properties
        public Store? Store { get; set; }
        public List<ProductPhoto>? Photos { get; set; }
        public List<ProductTag>? Tags { get; set; }
        public Offer? Offer { get; set; }
        public List<OrderDetail>? Orders { get; set; }
        public List<CartItem>? Carts { get; set; }
        public List<WishListItem>? WishLists { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}