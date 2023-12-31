using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public interface IWishListItemService : IEntityBaseRepository<WishListItem>
    {
        Task<List<WishListItem>> GetWishListByUserIdAsync(string userId);

        Task<WishListItem> GetByProductIdAsync(int productId);
    }
}