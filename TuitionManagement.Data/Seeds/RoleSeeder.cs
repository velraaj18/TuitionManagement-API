using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TuitionManagement.Data.Seeds
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = 
            [
                "Admin", "Teacher", "Student"
            ];

            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}