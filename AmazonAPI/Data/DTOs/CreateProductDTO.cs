using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Structures;
using AmazonAPI.Models;

namespace AmazonAPI.Data.DTOs
{
    public class CreateProductDTO
    {
        [Required, MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int StoreId { get; set; }
        public List<KeyValuePair<string, string>>? Tags { get; set; }
        public List<PhotoStruct>? Photos { get; set; }
    }
}