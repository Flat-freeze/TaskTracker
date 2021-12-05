using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models;

public partial class Command : BaseEntity
{
    public Command()
    {
        Users = new HashSet<ApplicationUser>();
        Projects = new HashSet<Project>();
    }

    public virtual ICollection<ApplicationUser> Users { get; set; }
    public virtual ICollection<Project> Projects { get; set; }
}
