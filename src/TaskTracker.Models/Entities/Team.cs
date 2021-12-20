namespace TaskTracker.Models;

public class Team : BaseEntity
{
	public Team()
	{
		Users    = new HashSet<ApplicationUser>();
		Projects = new HashSet<Project>();
	}

	public virtual ICollection<ApplicationUser> Users    { get; set; }
	public virtual ICollection<Project>         Projects { get; set; }
}

