using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class OrderDetailService : EntityBaseRepository<OrderDetail>, IOrderDetailService
    {
        private readonly AppDbContext _context;
        public OrderDetailService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}