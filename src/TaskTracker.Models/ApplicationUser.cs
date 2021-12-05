using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Models;

public class ApplicationUser : IdentityUser, IBaseEntity
{
	public ApplicationUser() => Commands = new HashSet<Command>();

	public virtual ICollection<Command> Commands { get; set; }
	#region IBaseEntity Members

	public new Guid     Id        { get; set; }
	public     DateTime CreatedAt { get; set; }
	public     Guid     CreatedBy { get; set; }
	public     DateTime UpdatedAt { get; set; }
	public     Guid     UpdatedBy { get; set; }

	#endregion
}