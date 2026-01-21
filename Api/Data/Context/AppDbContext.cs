using Api.Features.Groups.Models;
using Api.Features.Projects.Models;
using Api.Features.UserGroups.Models;
using Api.Features.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}