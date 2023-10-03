using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class OrderService : EntityBaseRepository<Order>, IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}