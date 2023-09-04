using AlumniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.DataAccess;

public class AlumniDbContext: DbContext
{
    public AlumniDbContext(DbContextOptions<AlumniDbContext> ctx) : base(ctx)
    {
    }
    
    public DbSet<Test> Test { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Group> Group { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<EventInfo> EventInfo { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Posts)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId)
            .IsRequired();
        
        modelBuilder.Entity<Test>().HasData(SeedHelper.GetTestSeeds());
        modelBuilder.Entity<Post>().HasData(SeedHelper.GetPostSeeds());
        modelBuilder.Entity<EventInfo>().HasData(SeedHelper.GetEventInfoSeeds());
    }
}