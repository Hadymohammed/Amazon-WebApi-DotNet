using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class StoreService : EntityBaseRepository<Store>, IStoreService
    {
        private readonly AppDbContext _context;
        public StoreService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}