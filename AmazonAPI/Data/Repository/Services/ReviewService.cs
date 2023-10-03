using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class ReviewService : EntityBaseRepository<Review>, IReviewService
    {
        private readonly AppDbContext _context;
        public ReviewService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}