using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class WishListItemService : EntityBaseRepository<WishListItem>, IWishListItemService
    {
        private readonly AppDbContext _context;
        public WishListItemService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}