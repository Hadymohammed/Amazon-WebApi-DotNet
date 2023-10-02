using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonAPI.Data.Enums
{
    public static class UserRoles
    {
        public static string Admin { get; } = "Admin";
        public static string Customer { get; } = "Customer";
        public static string Seller { get; } = "Seller";

    }
}