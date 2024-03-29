﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "ivan@ivan.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ivan"
                };
                userManager.CreateAsync(user, "Password@123");

                ApplicationUser user1 = new ApplicationUser()
                {
                    Email = "ilya@ilya.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ilya"
                };
                userManager.CreateAsync(user1, "Password@123");
            }
        }
    }
}
