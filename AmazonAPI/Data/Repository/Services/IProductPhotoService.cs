using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public interface IProductPhotoService : IEntityBaseRepository<ProductPhoto>
    {
        Task<IEnumerable<ProductPhoto>> GetPhotosByProductIdAsync(int productId);
    }
}