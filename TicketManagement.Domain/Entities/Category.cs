namespace TicketManagement.Domain.Entities;

public class Category
{
	public Category()
	{
	}

	public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Event> Events { get; set; }
}