namespace TaskTracker.Models;

public class Command : BaseEntity
{
	public Command()
	{
		Users    = new HashSet<ApplicationUser>();
		Projects = new HashSet<Project>();
	}

	public virtual ICollection<ApplicationUser> Users    { get; set; }
	public virtual ICollection<Project>         Projects { get; set; }
}