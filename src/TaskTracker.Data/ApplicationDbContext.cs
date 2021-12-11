using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using TaskTracker.Models;

using Task = TaskTracker.Models.Task;

namespace TaskTracker.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) :
        base(options, operationalStoreOptions)
    { }

    public DbSet<Team> Commands { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>(u =>
                                       {
                                           u.HasKey(t => t.Id);

                                           u.HasMany(u => u.Commands).WithMany(c => c.Users).UsingEntity("UserCommand");

                                           u.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                                           u.Property(c => c.IdCreatedBy).HasColumnName("CreatedBy");
                                           u.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
                                           u.Property(c => c.IdUpdatedBy).HasColumnName("UpdatedBy");
                                       }
                                       );

        builder.Entity<Team>(c =>
                               {
                                   c.HasKey(c => c.Id);

                                   c.HasMany(c => c.Projects)
                                    .WithOne(p => p.Command)
                                    .HasForeignKey(p => p.CommandId)
                                    .OnDelete(DeleteBehavior.Cascade);

                                   c.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                                   c.Property(c => c.IdCreatedBy).HasColumnName("CreatedBy");
                                   c.HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.IdCreatedBy);
                                   c.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
                                   c.Property(c => c.IdUpdatedBy).HasColumnName("UpdatedBy");
                                   c.HasOne(c => c.UpdatedBy).WithMany().HasForeignKey(c => c.IdUpdatedBy);
                               }
                               );

        builder.Entity<Project>(p =>
                               {
                                   p.HasKey(p => p.Id);

                                   p.HasMany(p => p.Columns)
                                    .WithOne(c => c.Project)
                                    .HasForeignKey(c => c.ProjectId)
                                    .OnDelete(DeleteBehavior.Cascade);

                                   p.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                                   p.Property(c => c.IdCreatedBy).HasColumnName("CreatedBy");
                                   p.HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.IdCreatedBy);
                                   p.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
                                   p.Property(c => c.IdUpdatedBy).HasColumnName("UpdatedBy");
                                   p.HasOne(c => c.UpdatedBy).WithMany().HasForeignKey(c => c.IdUpdatedBy);
                               }
                               );

        builder.Entity<Column>(c =>
                              {
                                  c.HasKey(c => c.Id);

                                  c.HasMany(c => c.Tasks)
                                   .WithOne(t => t.Column)
                                   .HasForeignKey(t => t.ColumnID)
                                   .OnDelete(DeleteBehavior.Cascade);

                                  c.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                                  c.Property(c => c.IdCreatedBy).HasColumnName("CreatedBy");
                                  c.HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.IdCreatedBy);
                                  c.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
                                  c.Property(c => c.IdUpdatedBy).HasColumnName("UpdatedBy");
                                  c.HasOne(c => c.UpdatedBy).WithMany().HasForeignKey(c => c.IdUpdatedBy);
                              }
                              );

        builder.Entity<Task>(t =>
                            {
                                t.HasKey(t => t.Id);

                                t.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("now()");
                                t.Property(c => c.IdCreatedBy).HasColumnName("CreatedBy");
                                t.HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.IdCreatedBy);
                                t.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");
                                t.Property(c => c.IdUpdatedBy).HasColumnName("UpdatedBy");
                                t.HasOne(c => c.UpdatedBy).WithMany().HasForeignKey(c => c.IdUpdatedBy);
                            }
                            );

        base.OnModelCreating(builder);
    }
}