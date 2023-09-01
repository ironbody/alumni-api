using AlumniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.DataAccess;

public class AlumniDbContext: DbContext
{
    public AlumniDbContext(DbContextOptions<AlumniDbContext> ctx) : base(ctx)
    {
    }
    
    public DbSet<Test> Test { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>().HasData(SeedHelper.GetTestSeeds());
    }
}