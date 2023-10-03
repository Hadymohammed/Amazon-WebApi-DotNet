using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Data.Repository
{
    public interface IEntityBase
    {
        public int Id { get; set; }
    }
}