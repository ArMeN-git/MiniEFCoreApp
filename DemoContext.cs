using Microsoft.EntityFrameworkCore;
using MiniEFCoreApp.Entities;

namespace MiniEFCoreApp;

public class DemoContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<HomeTour> HomeTours => Set<HomeTour>();
    public DbSet<UserView> UserViews => Set<UserView>();
    public DbSet<AgentClient> AgentClients => Set<AgentClient>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserView>(e =>
        {
            e.HasIndex(p => new { p.UserId, p.CoreListingId })
                .IsUnique();
        });

        modelBuilder.Entity<HomeTour>(e =>
        {
            e.HasQueryFilter(c => !c.Client.IsDeleted);
        });

        modelBuilder.Entity<Client>(e =>
        {
            e.HasQueryFilter(e => !e.IsDeleted);
            e.HasIndex(p => new { p.UserId, p.IsDeleted, p.DeletionDate }).IsUnique();
        });

        modelBuilder.Entity<AgentClient>(e =>
        {
            e.HasIndex(p => new { p.AgentUserId, p.ClientId })
             .IsUnique();

            e.HasOne(p => p.Client)
             .WithMany(p => p.ClientAgents)
             .HasForeignKey(p => p.ClientId);
        });
    }
}
