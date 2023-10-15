using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Data.DTOs
{
    public class StoreDetailsDTO
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BusinessEmail { get; set; }
        public string Description { get; set; }
        public string? Website { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}