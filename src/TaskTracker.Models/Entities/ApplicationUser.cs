using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Models;

public class ApplicationUser : IdentityUser, IBaseEntity
{
	public ApplicationUser() => Commands = new HashSet<Team>();

	public virtual ICollection<Team> Commands { get; set; }
	#region IBaseEntity Members

	public     DateTime CreatedAt { get; set; }
	public     string   IdCreatedBy { get; set; }
	public     DateTime UpdatedAt { get; set; }
	public     string   IdUpdatedBy { get; set; }

    #endregion
}