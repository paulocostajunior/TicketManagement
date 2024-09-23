﻿using System;
using Microsoft.AspNetCore.Identity;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity.Seed
{
	public class UserCreator
	{
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "John",
                LastName = "Smith",
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Azerty&01?");
            }
        }
    }
}

