namespace TaskTracker.Models;

public class Project : BaseEntity
{
	public Project() => Columns = new HashSet<Column>();

	public Guid CommandId { get; set; }

	public virtual Team             Command { get; set; }
	public virtual ICollection<Column> Columns { get; set; }
}