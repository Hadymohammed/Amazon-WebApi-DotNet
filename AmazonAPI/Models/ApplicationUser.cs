using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AmazonAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [AllowNull]
        public string? Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [AllowNull]
        public string? ProfilePhoto { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //navigation properties
        public List<Store>? Stores { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<WishListItem>? WishListItems { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}