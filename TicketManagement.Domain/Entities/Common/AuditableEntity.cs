namespace TicketManagement.Domain.Entities.Common;

public class AuditableEntity
{
	public AuditableEntity()
	{
	}

    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}