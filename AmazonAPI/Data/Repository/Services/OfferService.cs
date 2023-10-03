using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Models;

namespace AmazonAPI.Data.Repository.Services
{
    public class OfferService : EntityBaseRepository<Offer>, IOfferService
    {
        private readonly AppDbContext _context;
        public OfferService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}