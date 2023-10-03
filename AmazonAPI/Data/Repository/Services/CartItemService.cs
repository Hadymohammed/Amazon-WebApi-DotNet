using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class CartItemService : EntityBaseRepository<CartItem>, ICartItemService
    {
        private readonly AppDbContext _context;
        public CartItemService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}