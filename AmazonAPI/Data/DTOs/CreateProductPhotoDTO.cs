using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Data.DTOs
{
    public class CreateProductPhotoDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}