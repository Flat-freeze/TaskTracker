namespace TaskTracker.Models;

public class Task : BaseEntity
{
	public Guid ColumnID { get; set; }

	public virtual Column Column { get; set; }
}