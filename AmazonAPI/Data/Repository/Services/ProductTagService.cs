using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class ProductTagService : EntityBaseRepository<ProductTag>, IProductTagService
    {
        private readonly AppDbContext _context;
        public ProductTagService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}