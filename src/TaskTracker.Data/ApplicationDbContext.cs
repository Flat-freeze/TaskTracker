using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using TaskTracker.Models;

using Task = TaskTracker.Models.Task;

namespace TaskTracker.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(u =>
            {
                u.HasKey(t => t.Id);

                u.HasMany(u => u.Commands)
                .WithMany(c => c.Users)
                .UsingEntity("UserCommand");

                u.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                u.Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
            });
            builder.Entity<Command>(c =>
            {
                c.HasKey(c => c.Id);

                c.HasMany(c => c.Projects).WithOne(p => p.Command).HasForeignKey(p=>p.CommandId).OnDelete(DeleteBehavior.Cascade);

                c.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                c.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
            });
            builder.Entity<Project>(p =>
            {
                p.HasKey(p => p.Id);

                p.HasMany(p=>p.Columns).WithOne(c=>c.Project).HasForeignKey(c=>c.ProjectId).OnDelete(DeleteBehavior.Cascade);

                p.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                p.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
            });
            builder.Entity<Column>(c =>
            {
                c.HasKey(c => c.Id);

                c.HasMany(c=>c.Tasks).WithOne(t=>t.Column).HasForeignKey(t=>t.ColumnID).OnDelete(DeleteBehavior.Cascade);

                c.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                c.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
            });
            builder.Entity<Task>(t =>
            {
                t.HasKey(t => t.Id);

                t.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                t.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
            });
            base.OnModelCreating(builder);
        }
    }
}