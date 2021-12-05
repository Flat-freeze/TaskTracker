namespace TaskTracker.Models;

public class Column:BaseEntity
{
    public Column()
    {
        Tasks = new HashSet<Task>();
    }
	public Guid ProjectId	{ get; set; }

	public virtual Project Project { get; set; }
	public virtual ICollection<Task> Tasks { get; set; }
}