
using Microsoft.EntityFrameworkCore;
using FintcsApi.Models;
using System.Text.Json;

namespace FintcsApi.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(FintcsDbContext context)
        {
            // Seed admin user if doesn't exist
            if (!await context.Users.AnyAsync(u => u.Username == "admin"))
            {
                var adminUser = new User
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                    Email = "admin@fintcs.com",
                    Phone = "9876543210",
                    Roles = "admin",
                    EDPNo = "EDP001",
                    Name = "Society Administrator",
                    AddressOffice = "123 Finance Tower, City Center",
                    AddressResidential = "45 Admin Colony, Main Road",
                    Designation = "Super Admin",
                    PhoneOffice = "011-22445566",
                    PhoneResidential = "011-77889900",
                    Mobile = "9876543210"
                };
                
                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
