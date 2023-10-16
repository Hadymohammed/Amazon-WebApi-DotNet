using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AmazonAPI.Data.Repository.Services
{
    public class WishListItemService : EntityBaseRepository<WishListItem>, IWishListItemService
    {
        private readonly AppDbContext _context;
        public WishListItemService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<WishListItem>> GetWishListByUserIdAsync(string userId)
        {
            var wishListItems = await _context.WishListItems.Where(w => w.CustomerId == userId).ToListAsync();
            return wishListItems;
        }

        public async Task<WishListItem> GetByProductIdAsync(int productId)
        {
            return await _context.WishListItems.FirstOrDefaultAsync(w => w.ProductId == productId);
        }
    }
}