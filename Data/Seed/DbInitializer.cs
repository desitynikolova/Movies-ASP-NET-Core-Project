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
            if (userManager.FindByEmailAsync("Admin1@abv.bg").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Admin1@abv.bg",
                    Email = "Admin1@abv.bg"
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin1@abv.bg").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
