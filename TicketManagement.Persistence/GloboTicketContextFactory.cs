using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TicketManagement.Persistence
{
	public class GloboTicketContextFactory : IDesignTimeDbContextFactory<GloboTicketDbContext>
    {
        public GloboTicketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GloboTicketDbContext>();
            optionsBuilder.UseSqlServer("GloboTicketTicketManagementConnectionString");

            return new GloboTicketDbContext(optionsBuilder.Options);
        }
    }
}

