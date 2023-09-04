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
    public DbSet<DirectMessage> DirectMessage { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<EventInfo> EventInfo { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ManyToMany
        modelBuilder.Entity<User>()
            .HasMany(u => u.Groups)
            .WithMany(g => g.Users)
            .UsingEntity<UserGroup>();
        
        //Disable cascade delete for DirectMessage
        modelBuilder.Entity<DirectMessage>()
            .HasOne(d => d.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(d => d.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<DirectMessage>()
            .HasOne(d => d.Recipient)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(d => d.RecipientId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<User>()
            .HasMany(e => e.Posts)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId)
            .IsRequired();
        
        //Seeding
        modelBuilder.Entity<Test>().HasData(SeedHelper.GetTestSeeds());
        modelBuilder.Entity<Post>().HasData(SeedHelper.GetPostSeeds());
        modelBuilder.Entity<EventInfo>().HasData(SeedHelper.GetEventInfoSeeds());
        modelBuilder.Entity<User>().HasData(SeedHelper.GetUserSeeds());
        modelBuilder.Entity<Group>().HasData(SeedHelper.GetGroupSeeds());
        modelBuilder.Entity<DirectMessage>().HasData(SeedHelper.GetMessageSeeds());
        modelBuilder.Entity<UserGroup>().HasData(SeedHelper.GetUserGroupSeeds());
        
    }
}