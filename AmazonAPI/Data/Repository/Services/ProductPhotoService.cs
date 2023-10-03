using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class ProductPhotoService : EntityBaseRepository<ProductPhoto>, IProductPhotoService
    {
        private readonly AppDbContext _context;
        public ProductPhotoService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}