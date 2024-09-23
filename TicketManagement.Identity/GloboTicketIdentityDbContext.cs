using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketManagement.Identity.Models;

namespace TicketManagement.Identity
{
	public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
       public GloboTicketIdentityDbContext()
       {

       }

        public GloboTicketIdentityDbContext(DbContextOptions<GloboTicketIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    }
}