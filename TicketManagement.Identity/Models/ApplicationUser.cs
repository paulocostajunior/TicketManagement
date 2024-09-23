using Microsoft.AspNetCore.Identity;

namespace TicketManagement.Identity.Models
{
	public class ApplicationUser : IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
	}
}

