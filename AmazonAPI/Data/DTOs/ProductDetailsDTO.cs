using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Structures;
using AmazonAPI.Models;

namespace AmazonAPI.Data.DTOs
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public double? Rating { get; set; }
        public int? StoreId { get; set; }
        public int? OfferId { get; set; }
        public List<PhotoStruct>? Photos { get; set; }
        public List<TagStruct>? Tags { get; set; }
    }
}