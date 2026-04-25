using Entitites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var passwordHasher = new PasswordHasher<User>();

            var admin = new User
            {
                Id = "f0091af6-14ee-4c5e-b913-30f987bac393",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!");
            var user = new User
            {
                Id = "a3da7156-4cca-44c8-ac03-2d6995589237",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "USER@TEST.COM",
                FirstName = "Basic",
                LastName = "User",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "User123!");
            builder.HasData(admin, user);
        }
    }
}
