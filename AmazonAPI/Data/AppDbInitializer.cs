using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonAPI.Data.Consts;
using AmazonAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace AmazonAPI.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Seller))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@amazon.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Super",
                        LastName = "Admin",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Phone = "01000000000",
                        Address = "Cairo, Egypt",
                        ProfilePhoto = Images.userProfile,
                    };
                    var res = await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string customerUserEmail = "customer@amazon.com";
                var appUser = await userManager.FindByEmailAsync(customerUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "Abdelhady",
                        LastName = "Mohmaed",
                        UserName = "customer-user",
                        Email = customerUserEmail,
                        EmailConfirmed = true,
                        Phone = "01000000000",
                        Address = "Cairo, Egypt",
                        ProfilePhoto = Images.userProfile,
                    };
                    await userManager.CreateAsync(newAppUser, "Customer@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Customer);
                }

                string sellerUserEmail = "seller@amazon.com";
                var sellerUser = await userManager.FindByEmailAsync(sellerUserEmail);
                if (sellerUser == null)
                {
                    var newSellerUser = new ApplicationUser()
                    {
                        FirstName = "Abdelhady",
                        LastName = "Mohmaed",
                        UserName = "seller-user",
                        Email = sellerUserEmail,
                        EmailConfirmed = true,
                        Phone = "01000000000",
                        Address = "Cairo, Egypt",
                        ProfilePhoto = Images.userProfile,
                    };
                    await userManager.CreateAsync(newSellerUser, "Seller@123");
                    await userManager.AddToRoleAsync(newSellerUser, UserRoles.Seller);
                }
            }
        }
    }
}