namespace TaskTracker.Models;

public interface IBaseEntity
{
	Guid     Id        { get; set; }
	DateTime CreatedAt { get; set; }
	Guid     CreatedBy { get; set; }
	DateTime UpdatedAt { get; set; }
	Guid     UpdatedBy { get; set; }
}

public class BaseEntity : IBaseEntity
{
	public string Title       { get; set; }
	public string Description { get; set; }
	#region IBaseEntity Members

	public Guid Id { get; set; }

	public Guid     CreatedBy { get; set; }
	public DateTime CreatedAt { get; set; }
	public Guid     UpdatedBy { get; set; }
	public DateTime UpdatedAt { get; set; }

	#endregion
}