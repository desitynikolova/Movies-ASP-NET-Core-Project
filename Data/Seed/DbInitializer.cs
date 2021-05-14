using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Seed
{
    public class DbInitializer
    {

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin12@abv.bg").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@abv.bg",
                    Email = "admin@abv.bg"
                };

                IdentityResult result = userManager.CreateAsync(user, "admin").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
