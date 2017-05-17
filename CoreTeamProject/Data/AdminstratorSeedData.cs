using CoreTeamProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Data
{
    public class AdminstratorSeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminstratorSeedData(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if(await _userManager.FindByEmailAsync("admin@thescoop.com") == null)
            {
                var adminRole = await _roleManager.FindByNameAsync("admin");
                if(adminRole == null)
                {
                    adminRole = new IdentityRole("admin");
                    await _roleManager.CreateAsync(adminRole);
                }

                ApplicationUser adminUser = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@thescoop.com"
                };

                await _userManager.CreateAsync(adminUser, "Admin@123456");
                await _userManager.SetLockoutEnabledAsync(adminUser, false);

                IdentityResult result = await _userManager.AddToRoleAsync(adminUser, "admin");
            }

            var userRole = await _roleManager.FindByNameAsync("user");
            if(userRole == null)
            {
                userRole = new IdentityRole("user");
                await _roleManager.CreateAsync(userRole);
            }
        }
    }
}
